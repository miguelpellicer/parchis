using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Parchis
{
    public partial class Principal : Form
    {
        //Se crea la variable dado, aqui se guardará el resultado de la tirada
        int dado;

        int terminadosamarillo = 0;
        int terminadosazul = 0;
        int terminadosverde = 0;
        int terminadosrojo = 0;
        //Se crea una variable por color para saber si han terminado
        //Se crea un array de 2 dimensiones donde se guardan las coordenadas de las casillas principales del tablero
        int[,] tablero = new int[68, 2] {{255, 5}, { 255, 30 }, { 255, 52 }, { 255, 75 },
            {255,99 }, {255,121 }, {255,142 }, {255,166 }, {234,181 }, {200,181 }, {168,181 },
            {137,181 }, {105,181 }, {73,181 }, {42,181 }, {9,181 }, {9,235 }, {9,292 },
            {42,292 }, {73,292 }, {106,292 }, {138,292 }, {170,292 }, {202,292 }, {231,292 }, {256,306 },
            {256,330 }, {256,352 }, {256,374 }, {256,398 }, {256,421 }, {256,443 }, {256,468 }, {330,468 },
            {406,468 }, {406,443 }, {406,421 }, {406,398 }, {406,374 }, {406,352 }, {406,330 }, {406,306 },
            {425,290 }, {465,290 }, {489,290 }, {521,290 }, {552,290 }, {585,290 }, {615,290 }, {651,290 },
            {651,234 }, {651,180 }, {616,180 }, {583,180 }, {552,180 }, {521,180 }, {490,180 }, {465,180 },
            {425,180 }, {404,166 }, {404,143 }, {404,122 }, {404,98 }, {404,75 }, {404,52 }, {404,30 },
            {404,5 }, {331,5 }};



        /*Se crea un objeto Random con el nombre de aleatorio, esto se utilizará
          para hacer la tirada de dados*/
        Random aleatorio = new System.Random();

        /*
         * Aqui creo un objeto por cada ficha con un constructor vacio
         * cuando se inizializa la aplicacion se le introduciran todos los valores
         * con un método llamado Crear
         */
        ficha rojo1 = new ficha(); ficha rojo2 = new ficha();
        ficha rojo3 = new ficha(); ficha rojo4 = new ficha();
        ficha verde1 = new ficha(); ficha verde2 = new ficha();
        ficha verde3 = new ficha(); ficha verde4 = new ficha();
        ficha azul1 = new ficha(); ficha azul2 = new ficha();
        ficha azul3 = new ficha(); ficha azul4 = new ficha();
        ficha amarillo1 = new ficha(); ficha amarillo2 = new ficha();
        ficha amarillo3 = new ficha(); ficha amarillo4 = new ficha();


        /*
         * Aqui creo un array de tipo ficha para meter todas las fichas y
         * poder comprobar mas tarde las posiciones de las fichas con un foreach
         * de esta manera puedo saber cuando 2 fichas estan en la misma casilla,
         * lo que significria que una se ha comido a otra
         */
        ficha[] fichas = new ficha[16];
        String turno_color = ""; //Se crea un string para saber de quien es el turno
        public Principal()
        {
            InitializeComponent();


        }

        private void pb_dado_Click(object sender, EventArgs e)
        {
            //Los dados solo se podran tirar si el boolean tirar_dados es verdadero
            //Así, el usuario no podrá tirarlos varias veces hasta conseguir el resultado que quiera

            //se genera un número aleatorio entre el 1 y el 6
            dado = aleatorio.Next(1, 7);

            //Se crea un switch en el que se hace visible un picture box y muestra ahi el resultado del dado
            switch (dado)
            {
                case 1:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_one;
                    
                    //Se fija a falso la variable tirar_dados para que el usuario no haga otra tirada
                    pb_dado.Enabled = false;
                    habilitar_fichas(turno_color);//Se activan las fichas de ese color
                    break;
                    
                    

                case 2:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_two;
                    //Se fija a falso la variable tirar_dados para que el usuario no haga otra tirada
                    pb_dado.Enabled = false;
                    habilitar_fichas(turno_color);//Se activan las fichas de ese color
                    break;
            

                case 3:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_three;
                    //Se fija a falso la variable tirar_dados para que el usuario no haga otra tirada
                    pb_dado.Enabled = false;
                    habilitar_fichas(turno_color);//Se activan las fichas de ese color
                    break;

                case 4:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_four;
                    //Se fija a falso la variable tirar_dados para que el usuario no haga otra tirada
                    pb_dado.Enabled = false;
                    habilitar_fichas(turno_color);//Se activan las fichas de ese color
                    break;

                case 5:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_five;
                    habilitar_fichas(turno_color);
                    pb_dado.Enabled = false;
                    break;

                case 6:
                    pb_resultado_dado.Visible = true;
                    pb_resultado_dado.Image = Properties.Resources.perspective_dice_six_faces_six;
                    //Se fija a falso la variable tirar_dados para que el usuario no haga otra tirada
                    pb_dado.Enabled = false;
                    habilitar_fichas(turno_color);//Se activan las fichas de ese color
                    break;
                default:
                    //Si ocurre un error de cualquier tipo al tirar los dados, el usuario vuelve a intentarlo
                    MessageBox.Show("Ha ocurrido un error, vuelve a intentarlo");
                    pb_dado.Enabled = true;
                    break;
            }
            

        }

        private void PasarTurno()
        {
            switch (turno_color)
            {
                //En este switch se cambia el turno al color siguiente
                case "ROJO":
                    turno_color = "VERDE";
                    txt_turno.Text = turno_color;
                    break;
                case "VERDE":
                    turno_color = "AMARILLO";
                    txt_turno.Text = turno_color;
                    break;
                case "AMARILLO":
                    turno_color = "AZUL";
                    txt_turno.Text = turno_color;
                    break;
                case "AZUL":
                    turno_color = "ROJO";
                    txt_turno.Text = turno_color;
                    break;
            }
        }

        private void Comer(int[,] tablero,int j, ficha actual)
        {
            //Se crea el método que se encargara de saber si una ficha ha sido comida
            if (j == 1)
                //j es el valor de un for que se utiliza para mover las fichas
            {
                for (int i = 0; i < fichas.Length; i++)
                { //Se recorre el array fichas
                    if (actual.Casilla == fichas[i].Casilla)
                    { //Si la casilla de la ficha "comedora" y de la "comida" coinciden...
                        switch (fichas[i].Nombre)
                        {
                            case "rojo1":
                                if (actual.Color == "rojo") { break; } //si ambas fichas son del mismo color no pasa nada
                                else
                                { //Si no son del mismo color la ficha comida vuelve a casa
                                    ficha_roja_1.Location = new Point(rojo1.Posicion_x_casa, rojo1.Posicion_y_casa);
                                    rojo1.Casa = true; //se fija casa como true
                                    rojo1.Casilla = 0; //se fija casilla como 0
                                    break;
                                }//este proceso se repite en todas las fichas
                            case "rojo2":
                                if (actual.Color == "rojo") { break; }
                                else
                                {
                                    ficha_roja_2.Location = new Point(rojo2.Posicion_x_casa, rojo2.Posicion_y_casa);
                                    rojo2.Casa = true;
                                    rojo2.Casilla = 0;
                                    break;
                                }

                            case "rojo3":
                                if (actual.Color == "rojo") { break; }
                                else
                                {
                                    ficha_roja_3.Location = new Point(rojo3.Posicion_x_casa, rojo3.Posicion_y_casa);
                                    rojo3.Casa = true;
                                    rojo3.Casilla = 0;
                                    break;
                                }

                            case "rojo4":
                                if (actual.Color == "rojo") { break; }
                                else
                                {
                                    ficha_roja_4.Location = new Point(rojo4.Posicion_x_casa, rojo4.Posicion_y_casa);
                                    rojo4.Casa = true;
                                    rojo4.Casilla = 0;
                                    break;
                                }

                            case "azul1":
                                if (actual.Color == "azul") { break; }
                                else
                                {
                                    ficha_azul_1.Location = new Point(azul1.Posicion_x_casa, azul1.Posicion_y_casa);
                                    azul1.Casa = true;
                                    azul1.Casilla = 0;
                                    break;
                                }

                            case "azul2":
                                if (actual.Color == "azul") { break; }
                                else
                                {
                                    ficha_azul_2.Location = new Point(azul2.Posicion_x_casa, azul2.Posicion_y_casa);
                                    azul2.Casa = true;
                                    azul2.Casilla = 0;
                                    break;
                                }

                            case "azul3":
                                if (actual.Color == "azul") { break; }
                                else
                                {
                                    ficha_azul_3.Location = new Point(azul3.Posicion_x_casa, azul3.Posicion_y_casa);
                                    azul3.Casa = true;
                                    azul3.Casilla = 0;
                                    break;
                                }
                            case "azul4":
                                if (actual.Color == "azul") { break; }
                                else
                                {
                                    ficha_azul_4.Location = new Point(azul4.Posicion_x_casa, azul4.Posicion_y_casa);
                                    azul4.Casa = true;
                                    azul4.Casilla = 0;
                                    break;
                                }
                            case "verde1":
                                if (actual.Color == "verde") { break; }
                                else
                                {
                                    ficha_verde_1.Location = new Point(verde1.Posicion_x_casa, verde1.Posicion_y_casa);
                                    verde1.Casa = true;
                                    verde1.Casilla = 0;
                                    break;
                                }
                            case "verde2":
                                if (actual.Color == "verde") { break; }
                                else
                                {
                                    ficha_verde_2.Location = new Point(verde2.Posicion_x_casa, verde2.Posicion_y_casa);
                                    verde2.Casa = true;
                                    verde2.Casilla = 0;
                                    break;
                                }
                            case "verde3":
                                if (actual.Color == "verde") { break; }
                                else
                                {
                                    ficha_verde_3.Location = new Point(verde3.Posicion_x_casa, verde3.Posicion_y_casa);
                                    verde3.Casa = true;
                                    verde3.Casilla = 0;
                                    break;
                                }
                            case "verde4":
                                if (actual.Color == "verde") { break; }
                                else
                                {
                                    ficha_verde_4.Location = new Point(verde4.Posicion_x_casa, verde4.Posicion_y_casa);
                                    verde4.Casilla = 0;
                                    verde4.Casa = true;
                                    break;
                                }
                            case "amarillo1":
                                if (actual.Color == "amarillo") { break; }
                                else
                                {
                                    ficha_amarilla_1.Location = new Point(amarillo1.Posicion_x_casa, amarillo1.Posicion_y_casa);
                                    amarillo1.Casa = true;
                                    amarillo1.Casilla = 0;
                                    break;
                                }
                            case "amarillo2":
                                if (actual.Color == "amarillo") { break; }
                                else
                                {
                                    ficha_amarilla_2.Location = new Point(amarillo2.Posicion_x_casa, amarillo2.Posicion_y_casa);
                                    amarillo2.Casilla = 0;
                                    amarillo2.Casa = true;
                                    break;
                                }
                            case "amarillo3":
                                if (actual.Color == "amarillo") { break; }
                                else
                                {
                                    ficha_amarilla_3.Location = new Point(amarillo3.Posicion_x_casa, amarillo3.Posicion_y_casa);
                                    amarillo3.Casa = true;
                                    amarillo3.Casilla = 0;
                                    break;
                                }
                            case "amarillo4":
                                if (actual.Color == "amarillo") { break; }
                                else
                                {
                                    ficha_amarilla_4.Location = new Point(amarillo4.Posicion_x_casa, amarillo4.Posicion_y_casa);
                                    amarillo4.Casa = true;
                                    amarillo4.Casilla = 0;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void deshabilitar_fichas(String color)
        {
            //en esta funcion se desactivaran las fichas de un color en especifico
            switch (color)
            {
                case "AMARILLO":
                    ficha_amarilla_1.Enabled = false;
                    ficha_amarilla_2.Enabled = false;
                    ficha_amarilla_3.Enabled = false;
                    ficha_amarilla_4.Enabled = false;
                    break;
                case "ROJO":
                    ficha_roja_1.Enabled = false;
                    ficha_roja_2.Enabled = false;
                    ficha_roja_3.Enabled = false;
                    ficha_roja_4.Enabled = false;
                    break;
                case "VERDE":
                    ficha_verde_1.Enabled = false;
                    ficha_verde_2.Enabled = false;
                    ficha_verde_4.Enabled = false;
                    ficha_verde_3.Enabled = false;
                    break;
                case "AZUL":
                    ficha_azul_1.Enabled = false;
                    ficha_azul_2.Enabled = false;
                    ficha_azul_3.Enabled = false;
                    ficha_azul_4.Enabled = false;
                    break;
                default:
                    //por defecto se desactivaran todas
                    ficha_amarilla_1.Enabled = false;
                    ficha_amarilla_2.Enabled = false;
                    ficha_amarilla_3.Enabled = false;
                    ficha_amarilla_4.Enabled = false;
                    ficha_roja_1.Enabled = false;
                    ficha_roja_2.Enabled = false;
                    ficha_roja_3.Enabled = false;
                    ficha_roja_4.Enabled = false;
                    ficha_verde_1.Enabled = false;
                    ficha_verde_2.Enabled = false;
                    ficha_verde_4.Enabled = false;
                    ficha_verde_3.Enabled = false;
                    ficha_azul_1.Enabled = false;
                    ficha_azul_2.Enabled = false;
                    ficha_azul_3.Enabled = false;
                    ficha_azul_4.Enabled = false;
                    break;


            }
            
            
            
            
            
        }

        private void habilitar_fichas(String color)
        {
            switch (color)
            {
                //en esta funcion se activaran las fichas de un color en especifico
                case "AMARILLO":
                    ficha_amarilla_1.Enabled = true;
                    ficha_amarilla_2.Enabled = true;
                    ficha_amarilla_3.Enabled = true;
                    ficha_amarilla_4.Enabled = true;
                    break;
                case "ROJO":
                    ficha_roja_1.Enabled = true;
                    ficha_roja_2.Enabled = true;
                    ficha_roja_3.Enabled = true;
                    ficha_roja_4.Enabled = true;
                    break;
                case "VERDE":
                    ficha_verde_1.Enabled = true;
                    ficha_verde_2.Enabled = true;
                    ficha_verde_4.Enabled = true;
                    ficha_verde_3.Enabled = true;
                    break;
                case "AZUL":
                    ficha_azul_1.Enabled = true;
                    ficha_azul_2.Enabled = true;
                    ficha_azul_3.Enabled = true;
                    ficha_azul_4.Enabled = true;
                    break;
                default:
                    //por defecto se activaran todas
                    ficha_amarilla_1.Enabled = true;
                    ficha_amarilla_2.Enabled = true;
                    ficha_amarilla_3.Enabled = true;
                    ficha_amarilla_4.Enabled = true;
                    ficha_roja_1.Enabled = true;
                    ficha_roja_2.Enabled = true;
                    ficha_roja_3.Enabled = true;
                    ficha_roja_4.Enabled = true;
                    ficha_verde_1.Enabled = true;
                    ficha_verde_2.Enabled = true;
                    ficha_verde_4.Enabled = true;
                    ficha_verde_3.Enabled = true;
                    ficha_azul_1.Enabled = true;
                    ficha_azul_2.Enabled = true;
                    ficha_azul_3.Enabled = true;
                    ficha_azul_4.Enabled = true;
                    break;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            /*
             * Para que los objetos sean globales, se crean con un constructor vacio arriba
             * y aqui an inizializar la aplicacion se introducen todos los valores utilizando el métido
             * Crear
             */
            rojo1.Crear(ficha_roja_1.Location.X, ficha_roja_1.Location.Y, "rojo1", "rojo");
            rojo2.Crear(ficha_roja_2.Location.X, ficha_roja_2.Location.Y, "rojo2", "rojo");
            rojo3.Crear(ficha_roja_3.Location.X, ficha_roja_3.Location.Y, "rojo3", "rojo");
            rojo4.Crear(ficha_roja_4.Location.X, ficha_roja_4.Location.Y, "rojo4", "rojo");
            verde1.Crear(ficha_verde_1.Location.X, ficha_verde_1.Location.Y, "verde1", "verde");
            verde2.Crear(ficha_verde_2.Location.X, ficha_verde_2.Location.Y, "verde2", "verde");
            verde3.Crear(ficha_verde_3.Location.X, ficha_verde_3.Location.Y, "verde3", "verde");
            verde4.Crear(ficha_verde_4.Location.X, ficha_verde_4.Location.Y, "verde4", "verde");
            azul1.Crear(ficha_azul_1.Location.X, ficha_azul_1.Location.Y, "azul1", "azul");
            azul2.Crear(ficha_azul_2.Location.X, ficha_azul_2.Location.Y, "azul2", "azul");
            azul3.Crear(ficha_azul_3.Location.X, ficha_azul_3.Location.Y, "azul3", "azul");
            azul4.Crear(ficha_azul_4.Location.X, ficha_azul_4.Location.Y, "azul4", "azul");
            amarillo1.Crear(ficha_amarilla_1.Location.X, ficha_amarilla_1.Location.Y, "amarillo1", "amarillo");
            amarillo2.Crear(ficha_amarilla_2.Location.X, ficha_amarilla_2.Location.Y, "amarillo2", "amarillo");
            amarillo3.Crear(ficha_amarilla_3.Location.X, ficha_amarilla_3.Location.Y, "amarillo3", "amarillo");
            amarillo4.Crear(ficha_amarilla_4.Location.X, ficha_amarilla_4.Location.Y, "amarillo4", "amarillo");
            /*
             * Aqui introduzco los valores al array creado arriba y el color de la ficha
             */

            fichas[0] = rojo1; fichas[1] = rojo2; fichas[2] = rojo3; fichas[3] = rojo4;
            fichas[4] = verde1; fichas[5] = verde2; fichas[6] = verde3; fichas[7] = verde4;
            fichas[8] = azul1; fichas[9] = azul2; fichas[10] = azul3; fichas[11] = azul4;
            fichas[12] = amarillo1; fichas[13] = amarillo2; fichas[14] = amarillo3; fichas[15] = amarillo4;

            /*
             * Cuando el juego empieza aparece un pop-up del visual basic
             * en el que se pregunta que color es el que se va a utilizar
             * 
             * se comprueba que ese color esté bien escrito y si es el caso ese color será el que empieza
             */
            deshabilitar_fichas("todas");//Se deshabilitan todas las fichas
            Boolean error = true;
            while (error)
            {
                //sale un popup preguntando que color va a empezar;
                turno_color = Interaction.InputBox("¿Que color va a empezar?", "Color", "ROJO");
                if (turno_color.ToUpper().Equals("ROJO"))
                {
                    turno_color = "ROJO";
                    txt_turno.Text = turno_color;
                    error = false;
                }else if (turno_color.ToUpper().Equals("AZUL"))
                {
                    turno_color = "AZUL";
                    txt_turno.Text = turno_color;
                    error = false;
                }else if (turno_color.ToUpper().Equals("AMARILLO"))
                {
                    turno_color = "AMARILLO";
                    txt_turno.Text = turno_color;
                    error = false;
                }else if (turno_color.ToUpper().Equals("VERDE"))
                {
                    turno_color = "VERDE";
                    txt_turno.Text = turno_color;
                    error = false;
                }else
                {
                    error = true;
                }
            }




        }

        private void ficha_verde_3_Click(object sender, EventArgs e)
        {
            /*
             * despues de tirar el dado se habilitaran las fichas del color respectivo
             * si el dado es un 5 se llama a la funcion sacarcasa para que se saque una ficha de casa
             */
            if (fichas[6].Casa && dado == 5)
            {

                fichas[6].Sacarcasa();
                ficha_verde_3.Location = new Point(verde3.Posicion_x, verde3.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[6].Casa && dado != 5)
            {
                //Si no ha sacado un 5 y la ficha esta en casa se pasa turno y se deshabilitan las fichas
                //se habilita el dado
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    //este bucle se utiliza para mover las fichas y comer
                    verde3.Moverficha(dado, tablero);
                    ficha_verde_3.Location = new Point(verde3.Posicion_x, verde3.Posicion_y);
                    Comer(tablero, i, verde3);

                }
                //Se llama a la funcion pasar turno y se deshabilitan todas las fichas
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true; //se activa el dado
            }

            if (fichas[6].Terminado)//Si la ficha en cuestion ha terminado
            {
                ficha_verde_3.Visible = false; //se oculta
                terminadosverde++;//aumenta el contador de fichas verdes
                if(terminadosverde >= 4)
                {//Si han terminado las 4 gana el equipo verde y se cierra la aplicacion
                    MessageBox.Show("Ha ganado el equipo verde");
                    Application.Exit();
                }
            }
        }

        private void ficha_roja_1_Click(object sender, EventArgs e)
        {
            if (fichas[0].Casa && dado == 5)
            {
                
                fichas[0].Sacarcasa();
                ficha_roja_1.Location = new Point(rojo1.Posicion_x, rojo1.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[0].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    rojo1.Moverficha(dado, tablero);
                    ficha_roja_1.Location = new Point(rojo1.Posicion_x, rojo1.Posicion_y);
                    Comer(tablero, i, rojo1);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }

            if (fichas[0].Terminado)
            {
                ficha_roja_1.Visible = false;
                terminadosrojo++;
                if (terminadosrojo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo rojo");
                    Application.Exit();
                }
            }
        }

        private void ficha_roja_2_Click(object sender, EventArgs e)
        {
            if (fichas[1].Casa && dado == 5)
            {

                fichas[1].Sacarcasa();
                ficha_roja_2.Location = new Point(rojo2.Posicion_x, rojo2.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[1].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    rojo2.Moverficha(dado, tablero);
                    ficha_roja_2.Location = new Point(rojo2.Posicion_x, rojo2.Posicion_y);
                    Comer(tablero, i, rojo2);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[1].Terminado)
            {
                ficha_roja_2.Visible = false;
                terminadosrojo++;
                if (terminadosrojo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo rojo");
                    Application.Exit();
                }
            }
        }

        private void ficha_roja_3_Click(object sender, EventArgs e)
        {
            if (fichas[2].Casa && dado == 5)
            {

                fichas[2].Sacarcasa();
                ficha_roja_3.Location = new Point(rojo3.Posicion_x, rojo3.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[2].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    rojo3.Moverficha(dado, tablero);
                    ficha_roja_3.Location = new Point(rojo3.Posicion_x, rojo3.Posicion_y);
                    Comer(tablero, i, rojo3);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[2].Terminado)
            {
                ficha_roja_3.Visible = false;
                terminadosrojo++;
                if (terminadosrojo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo rojo");
                    Application.Exit();
                }
            }
        }

        private void ficha_roja_4_Click(object sender, EventArgs e)
        {
            if (fichas[3].Casa && dado == 5)
            {

                fichas[3].Sacarcasa();
                ficha_roja_4.Location = new Point(rojo4.Posicion_x, rojo4.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[3].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    rojo4.Moverficha(dado, tablero);
                    ficha_roja_4.Location = new Point(rojo4.Posicion_x, rojo4.Posicion_y);
                    Comer(tablero, i, rojo4);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[3].Terminado)
            {
                ficha_roja_4.Visible = false;
                terminadosrojo++;
                if (terminadosrojo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo rojo");
                    Application.Exit();
                }
            }
        }

        private void ficha_azul_1_Click(object sender, EventArgs e)
        {
            if (fichas[8].Casa && dado == 5)
            {

                fichas[8].Sacarcasa();
                ficha_azul_1.Location = new Point(azul1.Posicion_x, azul1.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[8].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    azul1.Moverficha(dado, tablero);
                    ficha_azul_1.Location = new Point(azul1.Posicion_x, azul1.Posicion_y);
                    Comer(tablero, i, azul1);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[8].Terminado)
            {
                ficha_azul_1.Visible = false;
                terminadosazul++;
                if (terminadosazul >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo azul");
                    Application.Exit();
                }
            }
        }

        private void ficha_azul_2_Click(object sender, EventArgs e)
        {
            if (fichas[9].Casa && dado == 5)
            {

                fichas[9].Sacarcasa();
                ficha_azul_2.Location = new Point(azul2.Posicion_x, azul2.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }else if (fichas[9].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    azul2.Moverficha(dado, tablero);
                    ficha_azul_2.Location = new Point(azul2.Posicion_x, azul2.Posicion_y);
                    Comer(tablero, i, azul2);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[9].Terminado)
            {
                ficha_azul_2.Visible = false;
                terminadosazul++;
                if (terminadosazul >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo azul");
                    Application.Exit();
                }
            }
        }

        private void ficha_azul_3_Click(object sender, EventArgs e)
        {
            if (fichas[10].Casa && dado == 5)
            {

                fichas[10].Sacarcasa();
                ficha_azul_3.Location = new Point(azul3.Posicion_x, azul3.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[10].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    azul3.Moverficha(dado, tablero);
                    ficha_azul_3.Location = new Point(azul3.Posicion_x, azul3.Posicion_y);
                    Comer(tablero, i, azul3);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[10].Terminado)
            {
                ficha_azul_3.Visible = false;
                terminadosazul++;
                if (terminadosazul >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo azul");
                    Application.Exit();
                }
            }
        }

        private void ficha_azul_4_Click(object sender, EventArgs e)
        {
            if (fichas[11].Casa && dado == 5)
            {

                fichas[11].Sacarcasa();
                ficha_azul_4.Location = new Point(azul4.Posicion_x, azul4.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[11].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    azul4.Moverficha(dado, tablero);
                    ficha_azul_4.Location = new Point(azul4.Posicion_x, azul4.Posicion_y);
                    Comer(tablero, i, azul4);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[11].Terminado)
            {
                ficha_azul_4.Visible = false;
                terminadosazul++;
                if (terminadosazul >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo azul");
                    Application.Exit();
                }
            }
        }

        private void ficha_amarilla_1_Click(object sender, EventArgs e)
        {
            if (fichas[12].Casa && dado == 5)
            {

                fichas[12].Sacarcasa();
                ficha_amarilla_1.Location = new Point(amarillo1.Posicion_x, amarillo1.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[12].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    amarillo1.Moverficha(dado, tablero);
                    ficha_amarilla_1.Location = new Point(amarillo1.Posicion_x, amarillo1.Posicion_y);
                    Comer(tablero, i, amarillo1);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[12].Terminado)
            {
                ficha_amarilla_1.Visible = false;
                terminadosamarillo++;
                if (terminadosamarillo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo amarillo");
                    Application.Exit();
                }
            }
        }

        private void ficha_amarilla_2_Click(object sender, EventArgs e)
        {
            if (fichas[13].Casa && dado == 5)
            {

                fichas[13].Sacarcasa();
                ficha_amarilla_2.Location = new Point(amarillo2.Posicion_x, amarillo2.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[13].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    amarillo2.Moverficha(dado, tablero);
                    ficha_amarilla_2.Location = new Point(amarillo2.Posicion_x, amarillo2.Posicion_y);
                    Comer(tablero, i, amarillo2);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[13].Terminado)
            {
                ficha_amarilla_2.Visible = false;
                terminadosamarillo++;
                if (terminadosamarillo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo amarillo");
                    Application.Exit();
                }
            }
        }

        private void ficha_amarilla_3_Click(object sender, EventArgs e)
        {
            if (fichas[14].Casa && dado == 5)
            {

                fichas[14].Sacarcasa();
                ficha_amarilla_3.Location = new Point(amarillo3.Posicion_x, amarillo3.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[14].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    amarillo3.Moverficha(dado, tablero);
                    ficha_amarilla_3.Location = new Point(amarillo3.Posicion_x, amarillo3.Posicion_y);
                    Comer(tablero, i, amarillo3);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }

            if (fichas[14].Terminado)
            {
                ficha_amarilla_3.Visible = false;
                terminadosamarillo++;
                if (terminadosamarillo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo amarillo");
                    Application.Exit();
                }
            }

        }

        private void ficha_verde_1_Click(object sender, EventArgs e)
        {
            if (fichas[4].Casa && dado == 5)
            {

                fichas[4].Sacarcasa();
                ficha_verde_1.Location = new Point(verde1.Posicion_x, verde1.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[4].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    verde1.Moverficha(dado, tablero);
                    ficha_verde_1.Location = new Point(verde1.Posicion_x, verde1.Posicion_y);
                    Comer(tablero, i, verde1);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[4].Terminado)
            {
                ficha_verde_1.Visible = false;
                terminadosverde++;
                if (terminadosverde >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo verde");
                    Application.Exit();
                }
            }
        }

        private void ficha_verde_2_Click(object sender, EventArgs e)
        {
            if (fichas[5].Casa && dado == 5)
            {

                fichas[5].Sacarcasa();
                ficha_verde_2.Location = new Point(verde2.Posicion_x, verde2.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[5].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    verde2.Moverficha(dado, tablero);
                    ficha_verde_2.Location = new Point(verde2.Posicion_x, verde2.Posicion_y);
                    Comer(tablero, i, verde2);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[5].Terminado)
            {
                ficha_verde_2.Visible = false;
                terminadosverde++;
                if (terminadosverde >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo verde");
                    Application.Exit();
                }
            }
        }

        private void ficha_verde_4_Click(object sender, EventArgs e)
        {
            if (fichas[7].Casa && dado == 5)
            {

                fichas[7].Sacarcasa();
                ficha_verde_4.Location = new Point(verde4.Posicion_x, verde4.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[7].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    verde4.Moverficha(dado, tablero);
                    ficha_verde_4.Location = new Point(verde4.Posicion_x, verde4.Posicion_y);
                    Comer(tablero, i, verde4);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[7].Terminado)
            {
                ficha_verde_4.Visible = false;
                terminadosverde++;
                if (terminadosverde >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo verde");
                    Application.Exit();
                }
            }
        }

        private void ficha_amarilla_4_Click(object sender, EventArgs e)
        {
            if (fichas[15].Casa && dado == 5)
            {

                fichas[15].Sacarcasa();
                ficha_amarilla_4.Location = new Point(amarillo4.Posicion_x, amarillo4.Posicion_y);
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;

            }
            else if (fichas[15].Casa && dado != 5)
            {
                deshabilitar_fichas("todas");
                PasarTurno();
                pb_dado.Enabled = true;
            }
            else
            {
                for (int i = dado; i > 0; i--)
                {
                    amarillo4.Moverficha(dado, tablero);
                    ficha_amarilla_4.Location = new Point(amarillo4.Posicion_x, amarillo4.Posicion_y);
                    Comer(tablero, i, amarillo4);

                }
                PasarTurno();
                deshabilitar_fichas("todas");
                pb_dado.Enabled = true;
            }
            if (fichas[15].Terminado)
            {
                ficha_amarilla_4.Visible = false;
                terminadosamarillo++; ;
                if (terminadosamarillo >= 4)
                {
                    MessageBox.Show("Ha ganado el equipo amarillo");
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //cuando se pulsa el boton se sale de la aplicación
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("reglas_parchis.pdf");
            //Cuando presionan el boton de como se juega se abre un PDF con las normas y las intrucciones
        }
    }
}
