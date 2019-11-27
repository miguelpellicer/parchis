using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parchis
{
    class ficha
    {
        //Se crea la clase ficha
        private int posicion_x;
        private int posicion_y;
        /*
         * Se van a guardar las coordenadas actuales de esa ficha y
         * las coordenadas de la casa de esa ficha (para cuando muera)
         */
        private int posicion_x_casa;
        private int posicion_y_casa;
        private Boolean casa;
        private Boolean muerta;
        private int casilla;
        private bool terminado;
        private bool entrar = false;
        int casillafinal = 0;
        //Se crea un boolean para saber si esa ficha esta en casa o no y si esta muerta o no
        private String color;
        private String nombre;
        //Se crea un string para saber el color de la ficha y el nombre

        //Se crean los setters y getters
        public int Casilla
        {
            get
            {
                return casilla;
            }

            set
            {
                casilla = value;
            }
        }
        public int Posicion_x
        {
            get
            {
                return posicion_x;
            }

            set
            {
                posicion_x = value;
            }
        }

        public bool Terminado
        {
            get
            {
                return terminado;
            }
            set
            {
                terminado = value;
            }
        }

        public bool Muerta
        {
            get
            {
                return muerta;
            }

            set
            {
                muerta = value;
            }
        }

        public int Posicion_y
        {
            get
            {
                return posicion_y;
            }

            set
            {
                posicion_y = value;
            }
        }

        public int Posicion_x_casa
        {
            get
            {
                return posicion_x_casa;
            }

            set
            {
                posicion_x_casa = value;
            }
        }

        public int Posicion_y_casa
        {
            get
            {
                return posicion_y_casa;
            }

            set
            {
                posicion_y_casa = value;
            }
        }

        public bool Casa
        {
            get
            {
                return casa;
            }

            set
            {
                casa = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public ficha()
        {
            //Se crea el constructor vacio (mas adelante se introduciran todos los valores)
            Posicion_x = 0;
            Posicion_x_casa = 0;
            Posicion_y = 0;
            Posicion_y_casa = 0;
            Casa = true;
            muerta = false;
            casilla = 0;
            color = "";
            nombre = "";
        }



        public void Crear(int posicion_x, int posicion_y, String nombre, String color)
        {
            /*
             * Se crea el metodo crear que introduce los valores a las fichas
             * 
             * En principio esto iba a ser un constructor, pero no lo he podido utilizar como tal
             * ya que necesitaba que los objetos fuesen globales pero no podia crearlos antes de
             * inizialidar el tablero ya que esta clase utiliza informacion de las fichas del tablero
             * para asignar los valores, entonces creo los objetos vacios y mas adelante les doy todos
             * los valores utilizando este método
             */


            this.Posicion_x = posicion_x;
            this.Posicion_y = posicion_y;
            Posicion_x_casa = this.Posicion_x;
            Posicion_y_casa = this.Posicion_y;
            casa = true;
            muerta = false;
            casilla = 0;
            this.color = color;
            this.nombre = nombre;
        }

        public void Sacarcasa()
        {
            /*
             * En este método se saca a la ficha de su respectiva casa
             * moviendoles a la casilla inicial y fijando la variable casa a falso
             */
            switch (color)
            {
                case "rojo":
                    posicion_x = 406;
                    posicion_y = 374;
                    casa = false;
                    break;
                case "amarillo":
                    posicion_x = 255;
                    posicion_y = 99;
                    casa = false;
                    break;
                case "azul":
                    posicion_x = 138;
                    posicion_y = 292;
                    casa = false;
                    break;
                case "verde":
                    posicion_x = 521;
                    posicion_y = 180;
                    casa = false;
                    break;
            }
        }

        public void Moverficha(int dado, int[,] tablero)
        {
            /*
             * Este es el método que hace que las fichas se puedan mover por el tablero
             * 
             * Se crea un boolean para saber si se ha encontrado la casilla en la que se encuentra
             * la ficha
             */
            bool encontrar = false;

            if (!entrar)
            {
                while (!encontrar)
                {
                    for (int i = 0; i < 68; i++)
                    {
                        if (tablero[i, 0] == posicion_x && tablero[i, 1] == posicion_y)
                        {
                            casilla = i + 1;
                            encontrar = true;

                            /*
                             * Mientras encontrar sea falso se va a recorrer el array tablero
                             * hasta que coincidan los valores con la posicion actual de la ficha
                             * 
                             * Se le suma 1 a la posicion del array donde se encuentran esas coordenadas
                             * y de esta manera se sabe el número de casilla en la que esta la ficha
                             */
                        }
                    }
                }
            }
            if ((casilla == 17 && color.Equals("azul"))|| (entrar && color.Equals("azul")))
            {
                /*
                 * Si la ficha llega al punto del tablero donde debe dejar de girar y entrar
                 * se fija entrar a true y se llama a la funcion entrar
                 */
                entrar = true;
                Entrar("azul", dado);
            }
            else if ((casilla == 34 && color.Equals("rojo")) || (entrar && color.Equals("rojo")))
            {
                entrar = true;
                Entrar("rojo", dado);
            }
            else if ((casilla == 51 && color.Equals("verde")) || (entrar && color.Equals("verde")))
            {
                entrar = true;
                Entrar("verde", dado);
            }else if ((casilla == 68 && color.Equals("amarillo"))|| (entrar && color.Equals("amarillo")))
            {
                entrar = true;
                Entrar("amarillo", dado);
            }
            else if (casilla == 68)
            {
                /*
                 * Si casilla es igual a 68 casilla se vuelve a reinciar a 0
                 * de esta manera no puedes salirte del array tablero
                 */
                casilla = 0;
                if (dado >= 1)
                {
                    //Mientras dado sea mayor o igual a 1 se fijan las nuevas posiciones de la ficha
                    casilla++;
                    posicion_x = tablero[(casilla - 1), 0];
                    posicion_y = tablero[(casilla - 1), 1];
                    casa = false;
                    //Se fija casa como falso ya que la ficha ya no esta en casa
                }
            }
            else if (dado >= 1)
            {
                //Mientras dado sea mayor o igual a 1 se fijan las nuevas posiciones de la ficha
                casilla++;
                posicion_x = tablero[(casilla - 1), 0];
                posicion_y = tablero[(casilla - 1), 1];
                casa = false;
                //Se fija casa como falso ya que la ficha ya no esta en casa
            }
        }

        private void Entrar(string color, int dado)
        {
            
            switch (color)
            {
                case "rojo":
                case "amarillo":
                    posicion_x = 331; //dada que la posicion x es la misma en cualquier casilla, se fija
                    break;

                case "azul":
                case "verde":
                    posicion_y = 236;
                    break;
            }

            if(dado >= 1 && casillafinal < 8)
            {
                //si el dado es mayor que 1 y la casillafinal es menor que 8 se incrementa casillafinal por 1
                casillafinal++;
                if (casillafinal <= 8)
                {//si la casilla es menor o igual a 8
                    switch (color)
                    {
                        case "rojo":
                            switch (casillafinal)
                            {
                                /*
                                 * dependiendo del color y de la casilla se fija una posicion
                                 */
                                case 1:
                                    posicion_y = 443;
                                    break;
                                case 2:
                                    posicion_y = 490;
                                    break;
                                case 3:
                                    posicion_y = 398;
                                    break;
                                case 4:
                                    posicion_y = 375;
                                    break;
                                case 5:
                                    posicion_y = 352;
                                    break;
                                case 6:
                                    posicion_y = 331;
                                    break;
                                case 7:
                                    posicion_y = 306;
                                    break;
                                case 8:
                                    posicion_y = 271;
                                    break;
                                default:
                                    posicion_y = 271;
                                    break;

                            }
                            break;
                        case "amarillo":
                            switch (casillafinal)
                            {
                                case 1:
                                    posicion_y = 29;
                                    break;
                                case 2:
                                    posicion_y = 52;
                                    break;
                                case 3:
                                    posicion_y = 74;
                                    break;
                                case 4:
                                    posicion_y = 99;
                                    break;
                                case 5:
                                    posicion_y = 121;
                                    break;
                                case 6:
                                    posicion_y = 144;
                                    break;
                                case 7:
                                    posicion_y = 167;
                                    break;
                                case 8:
                                    posicion_y = 197;
                                    break;
                                default:
                                    posicion_y = 197;
                                    break;

                            }
                            break;
                        case "azul":
                            switch (casillafinal)
                            {
                                case 1:
                                    posicion_x = 42;
                                    break;
                                case 2:
                                    posicion_x = 72;
                                    break;
                                case 3:
                                    posicion_x = 105;
                                    break;
                                case 4:
                                    posicion_x = 137;
                                    break;
                                case 5:
                                    posicion_x = 169;
                                    break;
                                case 6:
                                    posicion_x = 200;
                                    break;
                                case 7:
                                    posicion_x = 233;
                                    break;
                                case 8:
                                    posicion_x = 278;
                                    break;
                                default:
                                    posicion_x = 278;
                                    break;

                            }
                            break;

                        case "verde":
                            switch (casillafinal)
                            {
                                case 1:
                                    posicion_x = 617;
                                    break;
                                case 2:
                                    posicion_x = 585;
                                    break;
                                case 3:
                                    posicion_x = 557;
                                    break;
                                case 4:
                                    posicion_x = 522;
                                    break;
                                case 5:
                                    posicion_x = 490;
                                    break;
                                case 6:
                                    posicion_x = 457;
                                    break;
                                case 7:
                                    posicion_x = 424;
                                    break;
                                case 8:
                                    posicion_x = 384;
                                    break;
                                default:
                                    posicion_x = 384;
                                    break;

                            }
                            break;
                    }
                    if (casillafinal >= 8)
                    {
                        terminado = true; //si la casilla final es igual o mayor a 8 se fija terminado como verdad
                    }
                }

            }
            
        }
    }
}
