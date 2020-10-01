using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets
{
    public class Character
    {
        public static List<Character> roster = new List<Character>
        {
            new Character
            {
                id =  "gates",
                name= "Cyril Gates",
                description= "Hija del importante hombre de negocios Andrew Gates, dueño de la compañía de textiles más grande del sur de Inglaterra. Interesada en la lectura desde pequeña pasa gran rato de su tiempo en su cuarto escribiendo novelas, de la cuales han sido publicadas dos con moderado éxito.",
                stats= new Stats {
                    Bravery= 2,
                    Sanity= 4,
                    Intelligence= 2,
                    Physical = 4
                }
            },
            new Character
            {
                id= "lawrence",
                name="Joseph Lawrence",
                description= "Socio de Andrew Gates. Pasa sus tardes en su estudio haciendo trabajos en física. Es muy bueno en la caza, de niño su papá lo llevaba para que lo acompañara en las casas de campo que organizaba durante el verano y primavera.",
                stats= new Stats {
                    Bravery= 3,
                    Sanity= 3,
                    Intelligence= 3,
                    Physical= 3
                }
            },
            new Character
            {
                id= "werner",
                name= "Werner Lafayete",
                description= "",
                stats= new Stats{
                    Bravery= 0,
                    Sanity= 0,
                    Intelligence= 0,
                    Physical= 0
                }
            },
            new Character
            {
                id= "lewis",
                name="Andrea Lewis",
                description= "Viuda, anteriormente casada con un importante terrateniente que descubrió infortunio en una cabalgata donde se cayo de su caballo. Heredo una gran cantidad de tierras, hizo de ello mas de lo que los otros miembros de la familia jamás hayan pensado. Se alió recientemente para proporcionar cebada y trigo a una importante destiladora del sur de los Estados Unidos.",
                stats= new Stats{
                    Bravery= 4,
                    Sanity= 2,
                    Intelligence= 4,
                    Physical= 2
                }
            },
            new Character
            {
                id= "ordonez",
                name="Johana Ordoñez",
                description= "Hija y socia del hombre de negocio Carlos Ordoñez el dueño de uno de los ingenieros azucareros más grandes de México.",
                stats= new Stats {
                    Bravery= 3,
                    Sanity= 3,
                    Intelligence= 3,
                    Physical= 3
                }
            },
            new Character
            {
                id= "macarthur",
                name="Johann MacArthur",
                description= "Cazador de tesoros. Obtuvo su fama con los descubrimientos que hizo en una excavación hace algunos años, descubrió algunos preciosos artefactos de la cultura babilónica.",
                stats= new Stats {
                    Bravery= 3,
                    Sanity= 2,
                    Intelligence= 2,
                    Physical= 5
                }
            },
            new Character
            {
                id= "wu",
                name="John Wu",
                description= "Empresario chino de la ciudad de San Francisco. Propietario del hotel Sunrise, conocido en toda la costa este como uno de los lugares mas lujosos para hospedarse. Hay quienes dicen que después de una noche en un bar en compañía de varios amigos, surgió la idea de la galleta de la fortuna.",
                stats= new Stats {
                    Bravery= 3,
                    Sanity= 4,
                    Intelligence= 3,
                    Physical= 2
                }
            },
            new Character
            {
                id= "brown",
                name="Mathew Brown",
                description= "Dueño de un pequeño periódico en la ciudad de Nueva York, sin embargo, uno de los periodistas más sobresalientes de la ciudad.",
                stats= new Stats{
                    Bravery= 2,
                    Sanity= 2,
                    Intelligence= 5,
                    Physical= 3
                }
            }
        };

        public string name;
        public Stats stats;
        public string description;
        public string id;
    }
}
