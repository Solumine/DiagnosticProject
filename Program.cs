using Project;

//const string PATH = "";
//const string FILENAME = "Listing.txt";
//string FilePath = Path.Combine(PATH, FILENAME); 

string FilePath = "Listing.txt";
var Manager = new DiagnosticHandler(FilePath);
await Manager.Read();

var EPS = new Client("EPS");
var Clavier = new Card("Clavier", "CLA42V3.14");
var Teleco = new Card("Télécommande", "TLC42V1.70");
var OBA = new Person("Olivier", "BALMET", new DateTime(1995, 11, 16), Job.Technician, Service.AfterSales);
var MLA = new Person("Michel", "LAURETTA", new DateTime(1987, 01, 03), Job.Technician, Service.AfterSales);
var R1 = new Diagnostic(EPS, Clavier, OBA, new DateTime(2023, 06, 12), 78, 6);
var R2 = new Diagnostic(EPS, Teleco, MLA, new DateTime(2023, 01, 18), 42, 3);

Manager.Create(R1);

await Manager.Update();