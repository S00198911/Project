using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SSBEntities db = new SSBEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Query to display characters in the listbox
            var query = from a in db.Characters
                        select a;

            ListBoxCharacters.ItemsSource = query.ToList();
        }

        private void ListBoxCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = ListBoxCharacters.SelectedItem as Character;           

            if (selectedCharacter != null)
            {
                // Query to load character images
                var queryCharacterImages = from b in db.Characters
                            where b.Id == selectedCharacter.Id
                            select b.Image;

                // Image from database displayed in WPF
                imageCharacter1.Source = new BitmapImage(new Uri(queryCharacterImages.FirstOrDefault()));
                imageCharacter2.Source = new BitmapImage(new Uri(queryCharacterImages.FirstOrDefault()));
                imageCharacter3.Source = new BitmapImage(new Uri(queryCharacterImages.FirstOrDefault()));
                imageCharacter4.Source = new BitmapImage(new Uri(queryCharacterImages.FirstOrDefault()));
                imageCharacter5.Source = new BitmapImage(new Uri(queryCharacterImages.FirstOrDefault()));


                // ====================================================================================================
                // Query to display forward tilt data

                // Forward tilt start up frames
                var queryFTiltS = from b in db.FTilts
                             where b.CharacterId == selectedCharacter.Id
                             select b.StartUp;

                
                // Forward tilt on block frames
                var queryFTiltB = from b in db.FTilts
                             where b.CharacterId == selectedCharacter.Id
                             select b.OnBlock;

                
                // Forward tilt active frames
                var queryFTiltA = from b in db.FTilts
                             where b.CharacterId == selectedCharacter.Id
                             select b.Active;

                // Putting queries into string format when passing them into an object
                ForwardTilt FTilt = new ForwardTilt()
                {
                    startUp = string.Format("{0} On Startup", queryFTiltS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryFTiltB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryFTiltA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockFTiltS.Text = FTilt.startUp;
                queryTextBlockFTiltB.Text = FTilt.onBlock;
                queryTextBlockFTiltA.Text = FTilt.activeOn;


                // ====================================================================================================
                // Query to display up tilt data

                // Up tilt start up frames
                var queryUTiltS = from b in db.UTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.StartUp;

                
                // Up tilt on block frames
                var queryUTiltB = from b in db.UTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.OnBlock;
                

                // Up tilt active frames
                var queryUTiltA = from b in db.UTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.Active;


                // Putting queries into string format when passing them into an object
                UpTilt UTilt = new UpTilt()
                {
                    startUp = string.Format("{0} On Startup", queryUTiltS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryUTiltB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryUTiltA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockUTiltS.Text = UTilt.startUp;
                queryTextBlockUTiltB.Text = UTilt.onBlock;
                queryTextBlockUTiltA.Text = UTilt.activeOn;



                // ====================================================================================================
                // Query to display down tilt data

                // Down tilt start up frames
                var queryDTiltS = from b in db.DTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.StartUp;

                
               // Down tilt on block frames
                var queryDTiltB = from b in db.DTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.OnBlock;


                // Down tilt active frames
                var queryDTiltA = from b in db.DTilts
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.Active;


                // Putting queries into string format when passing them into an object
                DownTilt DTilt = new DownTilt() { 
                    startUp = string.Format("{0} On Startup", queryDTiltS.ToList().First()), 
                    onBlock = string.Format("{0} On Block", queryDTiltB.ToList().First()), 
                    activeOn = string.Format("Active on {0}", queryDTiltA.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockDTiltS.Text = DTilt.startUp;
                queryTextBlockDTiltB.Text = DTilt.onBlock;
                queryTextBlockDTiltA.Text = DTilt.activeOn;


                // ====================================================================================================
                // Query to display forward smash data

                // Forward smash start up frames
                var queryFSmashS = from b in db.FSmashes
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.StartUp;

  
                // Forward smash on block frames
                var queryFSmashB = from b in db.FSmashes
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.OnBlock;


                // Forward smash active frames
                var queryFSmashA = from b in db.FSmashes
                                  where b.CharacterId == selectedCharacter.Id
                                  select b.Active;


                // Putting queries into string format when passing them into an object
                ForwardSmash FSmash = new ForwardSmash()
                {
                    startUp = string.Format("{0} On Startup", queryFSmashS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryFSmashB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryFSmashA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockFSmashS.Text = FSmash.startUp;
                queryTextBlockFSmashB.Text = FSmash.onBlock;
                queryTextBlockFSmashA.Text = FSmash.activeOn;


                // ====================================================================================================
                // Query to display up smash data

                // Up smash start up frames
                var queryUSmashS = from b in db.UpSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;

                
                // Up smash on block frames
                var queryUSmashB = from b in db.UpSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.OnBlock;


                // Up smash active frames
                var queryUSmashA = from b in db.UpSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.Active;


                // Putting queries into string format when passing them into an object
                USmash USmash = new USmash()
                {
                    startUp = string.Format("{0} On Startup", queryUSmashS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryUSmashB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryUSmashA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockUSmashS.Text = USmash.startUp;
                queryTextBlockUSmashB.Text = USmash.onBlock;
                queryTextBlockUSmashA.Text = USmash.activeOn;


                // ====================================================================================================
                // Query to display down smash data

                // Down smash start up frames
                var queryDSmashS = from b in db.DownSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;


                // Down smash on block frames
                var queryDSmashB = from b in db.DownSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.OnBlock;


                // Down smash active frames
                var queryDSmashA = from b in db.DownSmashes
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.Active;


                // Putting queries into string format when passing them into an object
                DSmash DSmash = new DSmash()
                {
                    startUp = string.Format("{0} On Startup", queryDSmashS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryDSmashB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryDSmashA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockDSmashS.Text = DSmash.startUp;
                queryTextBlockDSmashB.Text = DSmash.onBlock;
                queryTextBlockDSmashA.Text = DSmash.activeOn;


                // ====================================================================================================
                // Query to display side B data

                // Side B start up frames
                var querySBS = from b in db.SideBs
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;


                // Side B on block frames
                var querySBB = from b in db.SideBs
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.OnBlock;


                // Side B active frames
                var querySBA = from b in db.SideBs
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.Active;


                // Putting queries into string format when passing them into an object
                SideSpecial SideB = new SideSpecial()
                {
                    startUp = string.Format("{0} On Startup", querySBS.ToList().First()),
                    onBlock = string.Format("{0} On Block", querySBB.ToList().First()),
                    activeOn = string.Format("Active on {0}", querySBA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockSBS.Text = SideB.startUp;
                queryTextBlockSBB.Text = SideB.onBlock;
                queryTextBlockSBA.Text = SideB.activeOn;


                // ====================================================================================================
                // Query to display up B data

                // Up B start up frames
                var queryUBS = from b in db.UpBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.StartUp;


                // Up B on block frames
                var queryUBB = from b in db.UpBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.OnBlock;


                // Up B active frames
                var queryUBA = from b in db.UpBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.Active;


                // Putting queries into string format when passing them into an object
                UpSpecial UpB = new UpSpecial()
                {
                    startUp = string.Format("{0} On Startup", queryUBS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryUBB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryUBA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockUBS.Text = UpB.startUp;
                queryTextBlockUBB.Text = UpB.onBlock;
                queryTextBlockUBA.Text = UpB.activeOn;


                // ====================================================================================================
                // Query to display down B data

                // Down B start up frames
                var queryDBS = from b in db.DownBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.StartUp;


                // Down B on block frames
                var queryDBB = from b in db.DownBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.OnBlock;


                // Down B active frames
                var queryDBA = from b in db.DownBs 
                               where b.CharacterId == selectedCharacter.Id
                               select b.Active;


                // Putting queries into string format when passing them into an object
                DownSpecial DownB = new DownSpecial()
                {
                    startUp = string.Format("{0} On Startup", queryDBS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryDBB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryDBA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockDBS.Text = DownB.startUp;
                queryTextBlockDBB.Text = DownB.onBlock;
                queryTextBlockDBA.Text = DownB.activeOn;


                // ====================================================================================================
                // Query to display neutral B data

                // Neutral B start up frames
                var queryNBS = from b in db.NeutralBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.StartUp;


                // Neutral B on block frames
                var queryNBB = from b in db.NeutralBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.OnBlock;


                // Neutral B active frames
                var queryNBA = from b in db.NeutralBs
                               where b.CharacterId == selectedCharacter.Id
                               select b.Active;


                // Putting queries into string format when passing them into an object
                NeutralSpecial NeutralB = new NeutralSpecial()
                {
                    startUp = string.Format("{0} On Startup", queryNBS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryNBB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryNBA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockNBS.Text = NeutralB.startUp;
                queryTextBlockNBB.Text = NeutralB.onBlock;
                queryTextBlockNBA.Text = NeutralB.activeOn;


                // ====================================================================================================
                // Query to display forward air data

                // Forward air start up frames
                var queryFAirS = from b in db.ForwardAirs
                               where b.CharacterId == selectedCharacter.Id
                               select b.StartUp;


                // Forward air on block frames
                var queryFAirB = from b in db.ForwardAirs
                               where b.CharacterId == selectedCharacter.Id
                               select b.OnBlock;


                // Forward air active frames
                var queryFAirA = from b in db.ForwardAirs
                               where b.CharacterId == selectedCharacter.Id
                               select b.Active;


                // Putting queries into string format when passing them into an object
                FAir ForwardAir = new FAir()
                {
                    startUp = string.Format("{0} On Startup", queryFAirS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryFAirB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryFAirA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockFAirS.Text = ForwardAir.startUp;
                queryTextBlockFAirB.Text = ForwardAir.onBlock;
                queryTextBlockFAirA.Text = ForwardAir.activeOn;


                // ====================================================================================================
                // Query to display up air data

                // Up air start up frames
                var queryUAirS = from b in db.UpAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;


                // Up air on block frames
                var queryUAirB = from b in db.UpAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.OnBlock;


                // Up air active frames
                var queryUAirA = from b in db.UpAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                UAir UpAir = new UAir()
                {
                    startUp = string.Format("{0} On Startup", queryUAirS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryUAirB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryUAirA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockUAirS.Text = UpAir.startUp;
                queryTextBlockUAirB.Text = UpAir.onBlock;
                queryTextBlockUAirA.Text = UpAir.activeOn;


                // ====================================================================================================
                // Query to display down air data

                // Down air start up frames
                var queryDAirS = from b in db.DownAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;


                // Down air on block frames
                var queryDAirB = from b in db.DownAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.OnBlock;


                // Down air active frames
                var queryDAirA = from b in db.DownAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                DAir DownAir = new DAir()
                {
                    startUp = string.Format("{0} On Startup", queryDAirS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryDAirB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryDAirA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockDAirS.Text = DownAir.startUp;
                queryTextBlockDAirB.Text = DownAir.onBlock;
                queryTextBlockDAirA.Text = DownAir.activeOn;


                // ====================================================================================================
                // Query to display back air data

                // Back air start up frames
                var queryBAirS = from b in db.BackAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;


                // Back air on block frames
                var queryBAirB = from b in db.NeutralAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.OnBlock;


                // Back air active frames
                var queryBAirA = from b in db.NeutralAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                BAir BackAir = new BAir()
                {
                    startUp = string.Format("{0} On Startup", queryBAirS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryBAirB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryBAirA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockBAirS.Text = BackAir.startUp;
                queryTextBlockBAirB.Text = BackAir.onBlock;
                queryTextBlockBAirA.Text = BackAir.activeOn;



                // ====================================================================================================
                // Query to display neutral air data

                // Neutral air start up frames
                var queryNAirS = from b in db.NeutralAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;


                // Neutral air on block frames
                var queryNAirB = from b in db.NeutralAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.OnBlock;


                // Neutral air active frames
                var queryNAirA = from b in db.NeutralAirs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                NAir NeutralAir = new NAir()
                {
                    startUp = string.Format("{0} On Startup", queryNAirS.ToList().First()),
                    onBlock = string.Format("{0} On Block", queryNAirB.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryNAirA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockNAirS.Text = NeutralAir.startUp;
                queryTextBlockNAirB.Text = NeutralAir.onBlock;
                queryTextBlockNAirA.Text = NeutralAir.activeOn;


                // ====================================================================================================
                // Query to display grab data

                // Grab start up frames
                var queryGrabS = from b in db.Grabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;

                // Grab active frames
                var queryGrabA = from b in db.Grabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                Grabs Grab = new Grabs()
                {
                    startUp = string.Format("{0} On Startup", queryGrabS.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryGrabA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockGrabS.Text = Grab.startUp;
                queryTextBlockGrabA.Text = Grab.activeOn;


                // ====================================================================================================
                // Query to display dash grab data

                // Dash Grab start up frames
                var queryDashGrabS = from b in db.DashGrabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;

                // Dash Grab active frames
                var queryDashGrabA = from b in db.DashGrabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                DashGrabs DashGrab = new DashGrabs()
                {
                    startUp = string.Format("{0} On Startup", queryDashGrabS.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryDashGrabA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockDashGrabS.Text = DashGrab.startUp;
                queryTextBlockDashGrabA.Text = DashGrab.activeOn;


                // ====================================================================================================
                // Query to display pivot grab data

                // Pivot Grab start up frames
                var queryPivotGrabS = from b in db.PivotGrabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;

                // Pivot Grab active frames
                var queryPivotGrabA = from b in db.PivotGrabs
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.Active;


                // Putting queries into string format when passing them into an object
                PivotGrabs PivotGrab = new PivotGrabs()
                {
                    startUp = string.Format("{0} On Startup", queryPivotGrabS.ToList().First()),
                    activeOn = string.Format("Active on {0}", queryPivotGrabA.ToList().First())
                };

                // Text blocks filled with object data
                queryTextBlockPivotGrabS.Text = PivotGrab.startUp;
                queryTextBlockPivotGrabA.Text = PivotGrab.activeOn;


                // ====================================================================================================
                // Query to display pummel data

                // Grab pummel frames
                var queryPummelS = from b in db.Pummels
                                 where b.CharacterId == selectedCharacter.Id
                                 select b.StartUp;

                // Putting queries into string format when passing them into an object
                Pummels Pummel = new Pummels() { startUp = string.Format("{0} On Startup", queryPummelS.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockPummelS.Text = Pummel.startUp;


                // ====================================================================================================
                // Query to display forward throw data

                // Forward throw frames
                var queryFThrowS = from b in db.FThrows
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;

                // Putting queries into string format when passing them into an object
                ForwardThrow FThrow = new ForwardThrow() { startUp = string.Format("{0} On Startup", queryFThrowS.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockFThrowS.Text = FThrow.startUp;


                // ====================================================================================================
                // Query to display back throw data

                // Back throw frames
                var queryBThrowS = from b in db.BThrows
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;

                // Putting queries into string format when passing them into an object
                BackThrow BThrow = new BackThrow() { startUp = string.Format("{0} On Startup", queryBThrowS.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockBThrowS.Text = BThrow.startUp;


                // ====================================================================================================
                // Query to display up throw data

                // Up throw frames
                var queryUThrowS = from b in db.UThrows
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;

                // Putting queries into string format when passing them into an object
                UpThrow UThrow = new UpThrow() { startUp = string.Format("{0} On Startup", queryUThrowS.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockUThrowS.Text = UThrow.startUp;


                // ====================================================================================================
                // Query to display down throw data

                // Up throw frames
                var queryDThrowS = from b in db.DThrows
                                   where b.CharacterId == selectedCharacter.Id
                                   select b.StartUp;

                // Putting queries into string format when passing them into an object
                DownThrow DThrow = new DownThrow() { startUp = string.Format("{0} On Startup", queryDThrowS.ToList().First()) };

                // Text blocks filled with object data
                queryTextBlockDThrowS.Text = DThrow.startUp;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Character selectedCharacter = ListBoxCharacters.SelectedItem as Character;

            var queryName = from b in db.Characters
                            where b.Id == selectedCharacter.Id
                            select b.Name;

            string test = string.Format("{0}", queryName.ToList().First());

            string data = JsonConvert.SerializeObject(test, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter("C:/Temp/Data.json"))
            {
                sw.Write(data);
                sw.Close();
            };
        }
    }
}