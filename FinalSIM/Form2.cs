using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalSIM
{
    public partial class Form2 : Form
    { 
        Form1 _form1;

        //Variables Inciales
        int
            cant_sim, 
            desde_sim, 
            hasta_sim;

        double
            llegada_cliente,
            demora_atencionA,
            demora_atencionB,
            demora_pedidoA,
            demora_pedidoB;


        public Form2 (string cant, string desde, string hasta, string llegadaCliente, string demoraAtencionA, string demoraAtencionB,
            string demoraPedidoA, string demoraPedidoB, Form1 principal)
        {
            InitializeComponent();
            cant_sim = int.Parse(cant);
            desde_sim = int.Parse(desde);
            hasta_sim = int.Parse(hasta);
            llegada_cliente = double.Parse(llegadaCliente);
            demora_atencionA = double.Parse(demoraAtencionA);
            demora_atencionB = double.Parse(demoraAtencionB);
            demora_pedidoA = double.Parse(demoraPedidoA);
            demora_pedidoB = double.Parse(demoraPedidoB);
            _form1 = principal;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _form1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        //Variables de simulacion
        int hora, min, seg; 
        
        //Evento Inicial
        string evento = "Inicializacion";

        //Reloj
        double h_reloj;
        double anth_reloj;
        double demora_mensaje = 0.10;

        //Generador Random
        Random random = new Random();

        //Cliente
        double rndLlegCliente,
               llegadaCliente,
               horaLlegCliente,
               antHrllegCliente,
               rnd,
               rndCompraCliente,
               rndMostrador,
               horaFinMostrador,
               horaMostrador,
               antHrFinMostrador,

               trasmitirMensaje,
               cola_dueño,
               ayudaCocina,
               menorTiempoPedido = 0,
               contador_dueño_mostrador = 0,
               contador_dueño_cocina = 0,
               contador_ayudante_libre = 0,

        //Dueño
               rndFinAten,
               horaAten,
               horaFinAten,
               antHrFinAten,

        //Ayudante
               rndFinPedido,
               horaPedido,
               horaFinPedido,
               antHrFinPedido;

        double anteriorColaDueño = 0;
 

        //Generador Colas Clientes
        List<Cliente> cola_cliente = new List<Cliente>();

        //Objeto Cliente
        Cliente cliente;
 
        //Estados  
        string estado_dueño;
        string estado_ayudante;

        string compraCliente;
        string anteriorEstadoDueño;
        string anteriorEstadoAyudante;

        bool bandera = false;
        bool bandera8 = true;

        private void btn_simular_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < cant_sim; i++)
            {
                if (i == 1)
                {
                    //EVENTO INICIALIZACION
                    evento = "Inicializacion";
                    h_reloj = 0;
                    rndLlegCliente = obtRandCliente(evento, estado_dueño, anteriorColaDueño);
                    llegadaCliente = obtHrCliente(rndLlegCliente, evento, estado_dueño, anteriorColaDueño) * 60;
                    horaLlegCliente = obtHrLlegCliente(h_reloj, llegadaCliente, antHrllegCliente, evento, estado_dueño, anteriorColaDueño);
                    antHrllegCliente = horaLlegCliente;
                   
                    estado_dueño = "Libre"; 
                    estado_ayudante = "Libre";
                    
                    cola_dueño = 0;

                    antHrFinAten = horaFinAten;

                    anteriorEstadoDueño = estado_dueño;
                    anteriorEstadoAyudante = estado_ayudante;
                }
                else

                {   
                    //CONTADORES                
                    if ((estado_dueño == "Ocupado Mostrador") || (estado_dueño == "Libre"))
                    {
                        contador_dueño_mostrador += h_reloj - anth_reloj;
                    }
                    if (estado_dueño == "Ocupado Cocina")
                    {
                        contador_dueño_cocina += h_reloj - anth_reloj;
                    }
                    if (estado_ayudante == "Libre")
                    {
                        contador_ayudante_libre += h_reloj - anth_reloj;
                    }

                    //Limpiar Columnas
                    rndLlegCliente = 0;
                    horaLlegCliente = 0;
                    rndCompraCliente = 0;
                    compraCliente = "";
                    rndMostrador = 0;
                    horaMostrador = 0;
                    horaFinAten = 0;
                    rndFinPedido = 0;
                    horaPedido = 0;
                    horaFinPedido = 0;
                    ayudaCocina = 0;


                    rndLlegCliente = obtRandCliente(evento, anteriorEstadoDueño, anteriorColaDueño);
                    llegadaCliente = obtHrCliente(rndLlegCliente, evento, anteriorEstadoDueño, anteriorColaDueño) * 60;
                    horaLlegCliente = obtHrLlegCliente(h_reloj, llegadaCliente, antHrllegCliente ,evento, anteriorEstadoDueño, anteriorColaDueño);
                    antHrllegCliente = horaLlegCliente;

                    rndCompraCliente = obtRandCompra(evento, anteriorEstadoDueño, anteriorColaDueño);
                    
                    if (rndCompraCliente == 0)
                    {
                        compraCliente = "";
                    }
                    if (rndCompraCliente <= 0.80 && rndCompraCliente > 0)
                    {
                       compraCliente = "Golosina";
                       rndMostrador = obtRandMostrador(rndCompraCliente, evento, anteriorEstadoDueño, anteriorColaDueño);                         
                       horaMostrador = obtHrMostrador(rndMostrador, evento, estado_dueño, anteriorColaDueño) * 60;
                       horaFinMostrador = obtHrFinMostrador(h_reloj, horaMostrador, antHrFinMostrador, evento, anteriorEstadoDueño, anteriorColaDueño);
                       antHrFinMostrador = horaFinMostrador;

                    }
                    if (rndCompraCliente > 0.80)
                    {
                       compraCliente = "Comida Rapida";
                       horaFinMostrador = 0;
                       trasmitirMensaje = (h_reloj + (demora_mensaje * 60));
                    }

                    rndFinPedido = obtRandPedido(evento, estado_dueño);
                    horaPedido = obtHrPedido(rndFinPedido, evento, estado_dueño) * 60;
                    horaFinPedido = obtHrFinPedido(h_reloj, horaPedido, antHrFinPedido, evento, estado_dueño);



                    //FIN TRASMICION PEDIDO
                    if (evento == "Fin Trasmicion Pedido")
                    {
                        if (compraCliente != "Comida Rapida")
                        {
                            trasmitirMensaje = 0;
                        }                                   
                        if (anteriorEstadoDueño == "Ocupado Mostrador" && anteriorColaDueño > 0)
                        {
                            cola_dueño -= 1;                                                     
                        }                                           
                        cliente = new Cliente();
                        cliente.setId(i);
                        cliente.setFin_atencion(horaFinPedido);
                        cliente.setHora_espera(horaPedido);
                        cola_cliente.Add(cliente);
                        bandera = true;
                    }
                    
                    //LLEGADA CLIENTE
                    if (evento == "Llegada Cliente")
                    {
                        if (anteriorEstadoDueño == "Ocupado Mostrador")
                        {
                            if (anteriorColaDueño >= 0)
                            {
                                cola_dueño += 1;
                            }                    
                        }
                    }
 
                    //FIN PEDIDO
                    if (evento == "Fin Pedido")
                    {
                        if (anteriorEstadoAyudante == "Libre")
                        {
                            horaFinPedido = 0;
                        }                                               
                        bandera8 = true;                       
                        cola_cliente.RemoveAll(x => x.getFin_atencion() == menorTiempoPedido);                       
                        if (cola_cliente.Count == 0)
                        {
                            menorTiempoPedido = 0;
                        }
                    }

                    //FIN ATENCION
                    if (evento == "Fin Atencion")
                    {
                        if (anteriorColaDueño == 0 && anteriorEstadoDueño == "Ocupado Mostrador")
                        {
                            horaFinMostrador = 0;
                        }
                        else
                        {                           
                            cola_dueño -= 1;
                        }
                    }

                    //MANEJO TIEMPO DE AYUDA COCINA
                    if (((anteriorEstadoDueño == "Ocupado Cocina" && estado_dueño == "Ocupado Mostrador") ||
                        (anteriorEstadoDueño == "Ocupado Cocina" && estado_dueño == "Ocupado Cocina")))
                    {
                        ayudaCocina = h_reloj - anth_reloj;
                    }

                    //MANEJO CAMBIO DE ESTADOS
                    estado_ayudante = funEstadoAyudante(evento, anteriorEstadoAyudante);
                    estado_dueño = funEstadoDueño(evento, cola_dueño, anteriorColaDueño, estado_ayudante, anteriorEstadoDueño);

                    anteriorEstadoDueño = estado_dueño;
                    anteriorEstadoAyudante = estado_ayudante;

                    anteriorColaDueño = cola_dueño;
                    
                    //RESTA TIEMPO DE AYUDA A LOS TIEMPOS DE PEDIDO
                    if (ayudaCocina > 0)
                    {
                        foreach (Cliente registro in cola_cliente)
                        {
                            double hola = (registro.getFin_atencion() - (ayudaCocina*2));
                            registro.setFin_atencion(hola);
                        }
                    }

                    //TOMAR SIEMPRE EL PEDIDO DE MENOR TIEMPO
                    if (cola_cliente.Count > 0)
                    {
                        foreach (Cliente registro in cola_cliente)
                        {
                            if (bandera8)
                            {
                                menorTiempoPedido = registro.getFin_atencion();
                                bandera8 = false;
                            }
                            if (registro.getFin_atencion() < menorTiempoPedido)
                            {
                                menorTiempoPedido = registro.getFin_atencion();
                            }
                        }
                    }

                    //MANEJO EVENTO TIEMPO MENOR AL RELOJ
                    if ((menorTiempoPedido != 0) && (menorTiempoPedido < h_reloj))
                    {
                        foreach (Cliente registro in cola_cliente)
                        {
                            if (registro.getFin_atencion() == menorTiempoPedido)
                            {
                                registro.setFin_atencion(h_reloj);
                                menorTiempoPedido = h_reloj;
                            }
                        }
                    }                    
                }

                //SIEMPRE MOSTRAR LA ULTIMA ITERACION 
                if (i == (cant_sim-1))
                {
                    dgv_sim.Rows.Add(
                        i,
                        evento,
                        pasar_a_tiempo2(h_reloj),
                        no_mostrar_ceros(rndLlegCliente),
                        no_mostrar_ceros2(pasar_a_tiempo(llegadaCliente)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaLlegCliente)),
                        no_mostrar_ceros(rndCompraCliente),
                        compraCliente,
                        no_mostrar_ceros(rndMostrador),
                        no_mostrar_ceros2(pasar_a_tiempo(horaMostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaFinMostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(trasmitirMensaje)),
                        no_mostrar_ceros(rndFinPedido),
                        no_mostrar_ceros2(pasar_a_tiempo(horaPedido)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaFinPedido)),
                        no_mostrar_ceros2(pasar_a_tiempo(menorTiempoPedido)),
                        cola_dueño,
                        estado_dueño,
                        estado_ayudante,
                        no_mostrar_ceros2(pasar_a_tiempo(ayudaCocina)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_dueño_mostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_dueño_cocina)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_ayudante_libre)));
                }

                //GESTOR DATA GRID VIEW 
                if (i >= desde_sim && i <= hasta_sim)
                {                   
                    dgv_sim.Rows.Add(
                        i, 
                        evento, 
                        pasar_a_tiempo2(h_reloj), 
                        no_mostrar_ceros(rndLlegCliente),
                        no_mostrar_ceros2(pasar_a_tiempo(llegadaCliente)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaLlegCliente)),
                        no_mostrar_ceros(rndCompraCliente),
                        compraCliente,
                        no_mostrar_ceros(rndMostrador),
                        no_mostrar_ceros2(pasar_a_tiempo(horaMostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaFinMostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(trasmitirMensaje)),
                        no_mostrar_ceros(rndFinPedido),
                        no_mostrar_ceros2(pasar_a_tiempo(horaPedido)),
                        no_mostrar_ceros2(pasar_a_tiempo(horaFinPedido)),
                        no_mostrar_ceros2(pasar_a_tiempo(menorTiempoPedido)),
                        cola_dueño,
                        estado_dueño,
                        estado_ayudante,
                        no_mostrar_ceros2(pasar_a_tiempo(ayudaCocina)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_dueño_mostrador)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_dueño_cocina)),
                        no_mostrar_ceros2(pasar_a_tiempo(contador_ayudante_libre))) ;


                    if (bandera)
                    {
                        dgv_sim.Columns.Add("hora_fin_esp_" + i.ToString(), "Fin Pedido Cliente " + i.ToString());
                        dgv_sim.Columns.Add("hora_fin_" + i.ToString(), "Tiempo Pedido Cliente " + i.ToString());
                        bandera = false;
                    }
                    foreach (Cliente registro in cola_cliente)
                    {
                        if (registro.getId() >= desde_sim)
                        {
                            dgv_sim.Rows[dgv_sim.Rows.Count - 1].Cells["hora_fin_esp_" + registro.getId().ToString()].Value = pasar_a_tiempo(registro.getFin_atencion());
                            dgv_sim.Rows[dgv_sim.Rows.Count - 1].Cells["hora_fin_" + registro.getId().ToString()].Value = pasar_a_tiempo(registro.getHora_espera());
                        }
                            
                    }
                    



                }
                

                //MANEJO RELOJ Y EVENTO
                evento = gestorEvento(horaLlegCliente, horaFinMostrador, trasmitirMensaje, menorTiempoPedido);
                anth_reloj = h_reloj;
                h_reloj = gestorTiempo(horaLlegCliente, horaFinMostrador, trasmitirMensaje, menorTiempoPedido);              
            }
        }

        //MANEJO EVENTO
        public string gestorEvento(params double[] bazbar)
        {
            if ((bazbar[3] == 0) && (bazbar[2] == 0) && (bazbar[1] == 0))
            {
                return "Llegada Cliente";
            }
            if ((bazbar[3] == 0) && (bazbar[2] != 0) && (bazbar[1] != 0))
            {
                if ((bazbar[2] < bazbar[1]))
                {
                    if ((bazbar[2] < bazbar[0]))
                    {
                        return "Fin Trasmicion Pedido";
                    }
                    else
                    {
                        if ((bazbar[1] < bazbar[0]))
                        {
                            return "Fin Atencion";
                        }
                        else
                        {
                            return "Llegada Cliente";
                        }
                    }
                }
                else
                {
                    if ((bazbar[1] < bazbar[0]))
                    {
                        return "Fin Atencion";
                    }
                    else
                    {
                        return "Llegada Cliente";
                    }
                }
            }
            if ((bazbar[3] == 0) && (bazbar[2] == 0) && (bazbar[1] != 0))
            {
                if ((bazbar[1] < bazbar[0]))
                {
                    return "Fin Atencion";
                }
                else
                {
                    return "Llegada Cliente";
                }
            }
            if ((bazbar[3] == 0) && (bazbar[2] != 0) && (bazbar[1] == 0))
            {
                if ((bazbar[2] < bazbar[0]))
                {
                    return "Fin Trasmicion Pedido";
                }
                else
                {
                    return "Llegada Cliente";
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] == 0) && (bazbar[1] == 0))
            {
                if ((bazbar[3] < bazbar[0]))
                {
                    return "Fin Pedido";
                }
                else
                {
                    return "Llegada Cliente";
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] != 0) && (bazbar[1] == 0))
            {
                if ((bazbar[3] < bazbar[2]))
                {
                    if ((bazbar[3] < bazbar[0]))
                    {
                        return "Fin Pedido";
                    }
                    else
                    {
                        if ((bazbar[2] < bazbar[0]))
                        {
                            return "Fin Trasmicion Pedido";
                        }
                        else
                        {
                            return "Llegada Cliente";
                        }
                    }
                }
                else
                {
                    if ((bazbar[2] < bazbar[0]))
                    {
                        return "Fin Trasmicion Pedido";
                    }
                    else
                    {
                        return "Llegada Cliente";
                    }
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] == 0) && (bazbar[1] != 0))
            {
                if ((bazbar[3] < bazbar[1]))
                {
                    if ((bazbar[3] < bazbar[0]))
                    {
                        return "Fin Pedido";
                    }
                    else
                    {
                        if ((bazbar[1] < bazbar[0]))
                        {
                            return "Fin Atencion";
                        }
                        else
                        {
                            return "Llegada Cliente";
                        }
                    }
                }
                else
                {
                    if ((bazbar[1] < bazbar[0]))
                    {
                        return "Fin Atencion";
                    }
                    else
                    {
                        return "Llegada Cliente";
                    }
                }
            }
            else
            {
                var min = bazbar.Min();
                if (min == bazbar[0])
                    return "Llegada Cliente";
                if (min == bazbar[1])
                    return "Fin Atencion";
                if (min == bazbar[2])
                {
                    return "Fin Trasmicion Pedido";
                }
                else
                    return "Fin Pedido";
            }
        }

        //MANEJO RELOJ
        public double gestorTiempo(params double[] bazbar)
        {
            if ((bazbar[3] == 0) && (bazbar[2] == 0) && (bazbar[1] == 0))
            {
                return bazbar[0];
            }
            if ((bazbar[3] == 0) && (bazbar[2] != 0) && (bazbar[1] != 0))
            {
                if ((bazbar[2] < bazbar[1]))
                {
                    if ((bazbar[2] < bazbar[0]))
                    {
                        return bazbar[2];
                    }
                    else
                    {
                        if ((bazbar[1] < bazbar[0]))
                        {
                            return bazbar[1];
                        }
                        else
                        {
                            return bazbar[0];
                        }
                    }
                }
                else
                {
                    if ((bazbar[1] < bazbar[0]))
                    {
                        return bazbar[1];
                    }
                    else
                    {
                        return bazbar[0];
                    }
                }
            }
            if ((bazbar[3] == 0) && (bazbar[2] == 0) && (bazbar[1] != 0))
            {
                if ((bazbar[1] < bazbar[0]))
                {
                    return bazbar[1];
                }
                else
                {
                    return bazbar[0];
                }
            }
            if ((bazbar[3] == 0) && (bazbar[2] != 0) && (bazbar[1] == 0))
            {
                if ((bazbar[2] < bazbar[0]))
                {
                    return bazbar[2];
                }
                else
                {
                    return bazbar[0];
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] == 0) && (bazbar[1] == 0))
            {
                if ((bazbar[3] < bazbar[0]))
                {
                    return bazbar[3];
                }
                else
                {
                    return bazbar[0];
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] != 0) && (bazbar[1] == 0))
            {
                if ((bazbar[3] < bazbar[2]))
                {
                    if ((bazbar[3] < bazbar[0]))
                    {
                        return bazbar[3];
                    }
                    else
                    {
                        if ((bazbar[2] < bazbar[0]))
                        {
                            return bazbar[2];
                        }
                        else
                        {
                            return bazbar[0];
                        }
                    }
                }
                else
                {
                    if ((bazbar[2] < bazbar[0]))
                    {
                        return bazbar[2];
                    }
                    else
                    {
                        return bazbar[0];
                    }
                }
            }
            if ((bazbar[3] != 0) && (bazbar[2] == 0) && (bazbar[1] != 0))
            {
                if ((bazbar[3] < bazbar[1]))
                {
                    if ((bazbar[3] < bazbar[0]))
                    {
                        return bazbar[3];
                    }
                    else
                    {
                        if ((bazbar[3] < bazbar[0]))
                        {
                            return bazbar[3];
                        }
                        else
                        {
                            return bazbar[0];
                        }
                    }
                }
                else
                {
                    if ((bazbar[1] < bazbar[0]))
                    {
                        return bazbar[1];
                    }
                    else
                    {
                        return bazbar[0];
                    }
                }
            }
            else
            {
                var min = bazbar.Min();
                if (min == bazbar[0])
                    return bazbar[0];
                if (min == bazbar[1])
                    return bazbar[1];
                if (min == bazbar[2])
                {
                    return bazbar[2];
                }
                else
                    return bazbar[3];
            }
        }

        //FUNCIONES VARIAS
        public string pasar_a_tiempo2(double segTot)
        {
            int segundos = (int)segTot;
            seg = segundos % 60;
            min = (segundos / 60) % 60;
            hora = (int)(segundos / 3600);
            TimeSpan interval = new TimeSpan(hora, min, seg);
            return interval.ToString();
        }
        public string no_mostrar_ceros(double var)
        {
            if (var == 0)
                return "";
            else
                return var.ToString();
        }
        public string no_mostrar_ceros2(string var)
        {
            if (var == "0")
                return "";
            else
                return var.ToString();
        }
        public string pasar_a_tiempo(double segTot)

        //FUNCIONES DE OBTENCION RANDOMS
        {
            int segundos = (int)segTot;
            seg = segundos % 60;
            min = (segundos / 60) % 60;
            hora = (int)(segundos / 3600);
            if (seg == 0 && min == 0 && hora == 0)
                return "0";
            else
            {
                TimeSpan interval = new TimeSpan(hora, min, seg);
                return interval.ToString();
            }

        }
        public double obtRandCliente(string evento, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            while (rnd == 0)
            {
                rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            }
            return eventoCliente(rnd, 0, evento, anteriorEstadoDueño, anteriorColaDueño);
        }
        public double obtRandPedido(string evento, string anteriorEstadoDueño)
        {
            rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            while (rnd == 0)
            {
                rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            }
            return eventoPedido(rnd, 0, evento, anteriorEstadoDueño);
        }
        public double obtRandCompra(string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            while (rnd == 0)
            {
                rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            }
            return eventoCompra(rnd, 0, eve, anteriorEstadoDueño, anteriorColaDueño);
        }
        public double obtRandMostrador(double r, string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            while (rnd == 0)
            {
                rnd = (Math.Truncate(random.NextDouble() * 100) / 100);
            }
            return eventoCompra(rnd, 0, eve, anteriorEstadoDueño, anteriorColaDueño);
        }

        //FUNCIONES DE OBTENCION TIEMPOS
        public double obtHrCliente(double r, string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            return eventoCliente(Math.Round(-(llegada_cliente) * Math.Log(1 - r), 2), 0, eve, anteriorEstadoDueño, anteriorColaDueño);
        }
        public double obtHrLlegCliente(double reloj, double hrCliente, double antCliente, string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            return eventoCliente(reloj + hrCliente, antCliente, eve, anteriorEstadoDueño, anteriorColaDueño);
        }    
        public double obtHrMostrador(double r, string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            return eventoCompra(Math.Round((demora_atencionB + (r * (demora_atencionA - demora_atencionB))), 2), 0, eve, anteriorEstadoDueño, anteriorColaDueño);
        }
        public double obtHrPedido(double r, string eve, string anteriorEstadoDueño)
        {
            return eventoFinPedido(Math.Round((demora_pedidoB + (r * (demora_pedidoA - demora_pedidoB))), 2), 0, eve, anteriorEstadoDueño);
        }
        public double obtHrFinMostrador(double reloj, double hrAten, double antAten, string eve, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            return eventoCompra(reloj + hrAten, antAten, eve, anteriorEstadoDueño, anteriorColaDueño);
        }
        public double obtHrFinPedido(double reloj, double hrAten, double antAten, string eve, string anteriorEstadoDueño)
        {
            return eventoFinPedido(reloj + hrAten, antAten, eve, anteriorEstadoDueño);
        }    

        //MANEJO DE FUNCIONES PARA OBTENER LOS RANDOMS O NO
        public double eventoCliente(double si, double no, string evto, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            if (evto.Equals("Inicializacion"))
            {
                return si;
            }
            if (evto.Equals("Llegada Cliente"))
            {
                return si;
            }
            if (evto.Equals("Fin Trasmicion Pedido"))
            {
                if (anteriorColaDueño > 0)
                {
                    return si;
                }
                else
                {
                    return no;
                }

            }
            if (evto.Equals("Fin Atencion"))
            {
                return no;                
            }
            else
            {
                return no;
            }
        }
        public double eventoCompra(double si, double no, string evto, string anteriorEstadoDueño, double anteriorColaDueño)
        {
            if (evto.Equals("Llegada Cliente"))
            {
                if (anteriorEstadoDueño == "Libre")
                {
                    return si;
                }
                if (anteriorEstadoDueño == "Ocupado Cocina")
                {
                    return si;
                }
                else
                {
                    return no;
                }
            }
            if (evto.Equals("Fin Trasmicion Pedido"))
            {
                if (anteriorColaDueño > 0)
                {
                    return si;
                }
                else
                {
                    return no;
                }             
            }
            if (evto.Equals("Fin Atencion"))
            {
                if (anteriorColaDueño > 0)
                {
                    return si;
                }
                else
                {
                    return no;
                }
            }
            else
            {
                return no;
            }
        }
        public double eventoPedido(double si, double no, string evto, string estado_dueño)
        {
            if ((evto.Equals("Fin Trasmicion Pedido")))
            {
                return si;
            }
            else
                return no;
        }     
        public double eventoFinPedido(double si, double no, string evto, string estado_dueño)
        {
            if ((evto.Equals("Fin Trasmicion Pedido")))
            {
                return si;
            }
            else
            {
                return no;
            }
        }

        //FUNCION MANEJO DE ESTADOS DUEÑO
        public string funEstadoDueño(string evento, double cola_dueño, double anteriorColaDueño, string estado_ayudante, string anteriorEstadoDueño)
        {
            if (evento == "Llegada Cliente")
            {
                if (cola_dueño == 0)
                {
                    return "Ocupado Mostrador";

                }
                else
                {
                    return "Ocupado Mostrador";

                }
            }
            if (evento == "Fin Atencion")
            {
                if (anteriorEstadoDueño == "Ocupado Mostrador" && anteriorColaDueño == 0 && estado_ayudante == "Libre")
                {
                    return "Libre";
                }
                if (cola_dueño == 0 && anteriorEstadoDueño == "Ocupado Mostrador" && anteriorColaDueño != 0)
                {
                    return "Ocupado Mostrador";
                }
                if (anteriorEstadoDueño == "Ocupado Mostrador" && anteriorColaDueño == 0 && estado_ayudante == "Ocupado")
                {
                    return "Ocupado Cocina";
                }
               
            }
            if (evento == "Fin Trasmicion Pedido")
            {
                if (anteriorColaDueño != 0)
                {
                    return "Ocupado Mostrador";
                }
                if (cola_dueño == 0 && estado_ayudante == "Ocupado")
                {
                    return "Ocupado Cocina";
                }
                if (cola_dueño != 0)
                {
                    return "Ocupado Mostrador";
                }
                if (anteriorEstadoDueño == "Ocupado Mostrador" && cola_dueño == 0 && (estado_ayudante == "Libre" || estado_ayudante == "Ocupado"))
                {
                    return "Ocupado Cocina";
                }
                else
                {
                    return "Libre";
                }
            }
            if (evento == "Fin Pedido")
            {
                if (anteriorEstadoDueño == "Ocupado Mostrador")
                {
                    return anteriorEstadoDueño;
                }
                else
                {
                    if (estado_ayudante == "Libre")
                    {
                        return "Libre";
                    }
                    else
                    {
                        return "Ocupado Cocina";
                    }
                }
               
            }
            else
            {
                return anteriorEstadoDueño;
            }
        }

        //FUNCION MANEJO DE ESTADOS AYUDANTE
        public string funEstadoAyudante(string evento, string anteriorEstadoDueño)
        {
            if (evento == "Fin Trasmicion Pedido")
            {
                if (cola_cliente.Count == 0)
                {
                    return "Ocupado";
                }
                else
                {
                    return "Ocupado";
                }
            }
            if (evento == "Fin Pedido")
            {
                if (cola_cliente.Count == 0)
                {
                    return "Libre";
                }
                else
                {
                    return "Ocupado";
                }
            }
            else
            {
                return anteriorEstadoDueño;
            }


        }
    }
}

