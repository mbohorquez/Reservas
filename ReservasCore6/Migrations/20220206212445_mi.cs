using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasCore6.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    NumeroHabitaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IdHotel);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Hotel_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hotel",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "IdHotel", "Activo", "Descripcion", "Latitud", "Longitud", "Nombre", "NumeroHabitaciones", "Pais" },
                values: new object[,]
                {
                    { 1, true, "Descripcion 1", 0.64243833121569482, 0.3701043890196597, "Hotel 1", 95, "Pais 1" },
                    { 2, true, "Descripcion 2", 0.12490440223962629, 0.33161098774873465, "Hotel 2", 89, "Pais 2" },
                    { 3, true, "Descripcion 3", 0.24378729261328114, 0.39790944964416908, "Hotel 3", 22, "Pais 3" },
                    { 4, true, "Descripcion 4", 0.081594966052063067, 0.7003974993458385, "Hotel 4", 73, "Pais 4" },
                    { 5, true, "Descripcion 5", 0.68895171171535274, 0.19478295474504237, "Hotel 5", 12, "Pais 5" },
                    { 6, true, "Descripcion 6", 0.077893811461345996, 0.96028868612359297, "Hotel 6", 64, "Pais 6" },
                    { 7, true, "Descripcion 7", 0.46497881711737721, 0.9380126851824464, "Hotel 7", 97, "Pais 7" },
                    { 8, true, "Descripcion 8", 0.84352081522247713, 0.94493852152794688, "Hotel 8", 92, "Pais 8" },
                    { 9, true, "Descripcion 9", 0.023770903007587552, 0.98817230775190534, "Hotel 9", 57, "Pais 9" },
                    { 10, true, "Descripcion 10", 0.43426541936919616, 0.12172822212512735, "Hotel 10", 53, "Pais 10" },
                    { 11, true, "Descripcion 11", 0.45900495217705251, 0.15964123448259893, "Hotel 11", 16, "Pais 11" },
                    { 12, true, "Descripcion 12", 0.65484286555521232, 0.23580690083553135, "Hotel 12", 14, "Pais 12" },
                    { 13, true, "Descripcion 13", 0.13560203482038524, 0.78196826697148847, "Hotel 13", 80, "Pais 13" },
                    { 14, true, "Descripcion 14", 0.065785391799705661, 0.49204568149795636, "Hotel 14", 34, "Pais 14" },
                    { 15, true, "Descripcion 15", 0.56261359966096591, 0.11223029625009218, "Hotel 15", 83, "Pais 15" },
                    { 16, true, "Descripcion 16", 0.91305158843700884, 0.45560135746739994, "Hotel 16", 22, "Pais 16" },
                    { 17, true, "Descripcion 17", 0.9600096383047978, 0.76323497774875027, "Hotel 17", 8, "Pais 17" },
                    { 18, true, "Descripcion 18", 0.8975014684217254, 0.17228393769223238, "Hotel 18", 81, "Pais 18" },
                    { 19, true, "Descripcion 19", 0.10212935949494095, 0.95209656367494611, "Hotel 19", 91, "Pais 19" },
                    { 20, true, "Descripcion 20", 0.48984276617701505, 0.32957335888750328, "Hotel 20", 65, "Pais 20" },
                    { 21, true, "Descripcion 21", 0.32717762187381993, 0.41997533092348072, "Hotel 21", 22, "Pais 21" },
                    { 22, true, "Descripcion 22", 0.86167116304173164, 0.20060904857454487, "Hotel 22", 33, "Pais 22" },
                    { 23, true, "Descripcion 23", 0.25623191892951891, 0.98092735496843775, "Hotel 23", 14, "Pais 23" },
                    { 24, true, "Descripcion 24", 0.96409126191970929, 0.33678284152328886, "Hotel 24", 17, "Pais 24" },
                    { 25, true, "Descripcion 25", 0.56662071184814844, 0.86814019789028363, "Hotel 25", 28, "Pais 25" },
                    { 26, true, "Descripcion 26", 0.9986843187791995, 0.25697154819830914, "Hotel 26", 15, "Pais 26" },
                    { 27, true, "Descripcion 27", 0.88630480303091841, 0.68850695203459877, "Hotel 27", 64, "Pais 27" },
                    { 28, true, "Descripcion 28", 0.20558441340285727, 0.19271175733803425, "Hotel 28", 76, "Pais 28" },
                    { 29, true, "Descripcion 29", 0.18586750581258116, 0.63870050685239821, "Hotel 29", 53, "Pais 29" },
                    { 30, true, "Descripcion 30", 0.41908916401069374, 0.90690516374630537, "Hotel 30", 62, "Pais 30" },
                    { 31, true, "Descripcion 31", 0.2053605821849952, 0.50751270470939536, "Hotel 31", 44, "Pais 31" },
                    { 32, true, "Descripcion 32", 0.6567455315464612, 0.72758981863776973, "Hotel 32", 22, "Pais 32" },
                    { 33, true, "Descripcion 33", 0.020551597027549828, 0.47348601248496203, "Hotel 33", 6, "Pais 33" },
                    { 34, true, "Descripcion 34", 0.23085864367567288, 0.3582107520752662, "Hotel 34", 14, "Pais 34" },
                    { 35, true, "Descripcion 35", 0.85208090527620506, 0.80238303317417992, "Hotel 35", 46, "Pais 35" },
                    { 36, true, "Descripcion 36", 0.118883948049194, 0.26675312002784946, "Hotel 36", 94, "Pais 36" },
                    { 37, true, "Descripcion 37", 0.74011974405267, 0.22349403394397394, "Hotel 37", 39, "Pais 37" },
                    { 38, true, "Descripcion 38", 0.60758409328970031, 0.64423851906988971, "Hotel 38", 49, "Pais 38" },
                    { 39, true, "Descripcion 39", 0.50308649401663952, 0.083358731258613261, "Hotel 39", 44, "Pais 39" },
                    { 40, true, "Descripcion 40", 0.005546677537339062, 0.016930125902463899, "Hotel 40", 69, "Pais 40" },
                    { 41, true, "Descripcion 41", 0.98602362533215082, 0.27910793407968548, "Hotel 41", 38, "Pais 41" },
                    { 42, true, "Descripcion 42", 0.7451362753713463, 0.097589957001154692, "Hotel 42", 90, "Pais 42" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "IdHotel", "Activo", "Descripcion", "Latitud", "Longitud", "Nombre", "NumeroHabitaciones", "Pais" },
                values: new object[,]
                {
                    { 43, true, "Descripcion 43", 0.012255406173518169, 0.5197979172738546, "Hotel 43", 35, "Pais 43" },
                    { 44, true, "Descripcion 44", 0.49914470218149043, 0.25746688600481127, "Hotel 44", 71, "Pais 44" },
                    { 45, true, "Descripcion 45", 0.43973334460617297, 0.62712413824686486, "Hotel 45", 85, "Pais 45" },
                    { 46, true, "Descripcion 46", 0.42802288101002695, 0.97982966890371526, "Hotel 46", 47, "Pais 46" },
                    { 47, true, "Descripcion 47", 0.015520916035647425, 0.96489773766590692, "Hotel 47", 56, "Pais 47" },
                    { 48, true, "Descripcion 48", 0.56654956601933559, 0.81861360606393063, "Hotel 48", 12, "Pais 48" },
                    { 49, true, "Descripcion 49", 0.714790704448242, 0.44489798765329081, "Hotel 49", 12, "Pais 49" },
                    { 50, true, "Descripcion 50", 0.083630928230477575, 0.49266680998080592, "Hotel 50", 65, "Pais 50" },
                    { 51, true, "Descripcion 51", 0.12093237585944294, 0.055263421511637767, "Hotel 51", 86, "Pais 51" },
                    { 52, true, "Descripcion 52", 0.71624688623950927, 0.47172307631997656, "Hotel 52", 63, "Pais 52" },
                    { 53, true, "Descripcion 53", 0.25849831989074645, 0.32372304421472631, "Hotel 53", 44, "Pais 53" },
                    { 54, true, "Descripcion 54", 0.23171563720318644, 0.77648243005569273, "Hotel 54", 97, "Pais 54" },
                    { 55, true, "Descripcion 55", 0.70843977058552532, 0.32977785717166963, "Hotel 55", 80, "Pais 55" },
                    { 56, true, "Descripcion 56", 0.44332064543335803, 0.31081664883797122, "Hotel 56", 41, "Pais 56" },
                    { 57, true, "Descripcion 57", 0.0017592149893990161, 0.80464490384488363, "Hotel 57", 94, "Pais 57" },
                    { 58, true, "Descripcion 58", 0.35898497369954974, 0.99474691546040694, "Hotel 58", 99, "Pais 58" },
                    { 59, true, "Descripcion 59", 0.20797832633851088, 0.94820868615947507, "Hotel 59", 31, "Pais 59" },
                    { 60, true, "Descripcion 60", 0.34879179625436385, 0.93544930331383169, "Hotel 60", 97, "Pais 60" },
                    { 61, true, "Descripcion 61", 0.25742161301396438, 0.019417986139927623, "Hotel 61", 22, "Pais 61" },
                    { 62, true, "Descripcion 62", 0.9204064533728239, 0.92500178508450892, "Hotel 62", 83, "Pais 62" },
                    { 63, true, "Descripcion 63", 0.77185911383939765, 0.42186952043582082, "Hotel 63", 76, "Pais 63" },
                    { 64, true, "Descripcion 64", 0.89594133571625456, 0.26948601803420869, "Hotel 64", 72, "Pais 64" },
                    { 65, true, "Descripcion 65", 0.4027906858727357, 0.53963315040448823, "Hotel 65", 79, "Pais 65" },
                    { 66, true, "Descripcion 66", 0.31971726859990046, 0.70835797226661368, "Hotel 66", 17, "Pais 66" },
                    { 67, true, "Descripcion 67", 0.82491861711444636, 0.97081889064450888, "Hotel 67", 28, "Pais 67" },
                    { 68, true, "Descripcion 68", 0.10315508721620925, 0.96600128531067686, "Hotel 68", 94, "Pais 68" },
                    { 69, true, "Descripcion 69", 0.50236324287098111, 0.048079417013275783, "Hotel 69", 27, "Pais 69" },
                    { 70, true, "Descripcion 70", 0.74751642016142616, 0.72567055793801616, "Hotel 70", 39, "Pais 70" },
                    { 71, true, "Descripcion 71", 0.14083044497207253, 0.17868035103768021, "Hotel 71", 93, "Pais 71" },
                    { 72, true, "Descripcion 72", 0.94236393647741101, 0.34188870552992201, "Hotel 72", 6, "Pais 72" },
                    { 73, true, "Descripcion 73", 0.28257288175711748, 0.65665758490310555, "Hotel 73", 48, "Pais 73" },
                    { 74, true, "Descripcion 74", 0.44823599156878147, 0.7982124780767279, "Hotel 74", 27, "Pais 74" },
                    { 75, true, "Descripcion 75", 0.66260622503917543, 0.81794737081000835, "Hotel 75", 26, "Pais 75" },
                    { 76, true, "Descripcion 76", 0.50165027065898815, 0.050043858191940127, "Hotel 76", 17, "Pais 76" },
                    { 77, true, "Descripcion 77", 0.7721678103517513, 0.054281947120030538, "Hotel 77", 91, "Pais 77" },
                    { 78, true, "Descripcion 78", 0.42509667614398294, 0.78275822903870251, "Hotel 78", 71, "Pais 78" },
                    { 79, true, "Descripcion 79", 0.95758168728070159, 0.75096778651858986, "Hotel 79", 34, "Pais 79" },
                    { 80, true, "Descripcion 80", 0.20672956011830124, 0.93268824601365663, "Hotel 80", 91, "Pais 80" },
                    { 81, true, "Descripcion 81", 0.35769577402499919, 0.01622515107337108, "Hotel 81", 36, "Pais 81" },
                    { 82, true, "Descripcion 82", 0.4446104114000029, 0.68590895878303815, "Hotel 82", 85, "Pais 82" },
                    { 83, true, "Descripcion 83", 0.98654607104104697, 0.85126060959848682, "Hotel 83", 70, "Pais 83" },
                    { 84, true, "Descripcion 84", 0.52301999669244092, 0.94553686187345143, "Hotel 84", 31, "Pais 84" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "IdHotel", "Activo", "Descripcion", "Latitud", "Longitud", "Nombre", "NumeroHabitaciones", "Pais" },
                values: new object[,]
                {
                    { 85, true, "Descripcion 85", 0.3064343702121205, 0.25846186807466631, "Hotel 85", 87, "Pais 85" },
                    { 86, true, "Descripcion 86", 0.51330725972598557, 0.68966957385433381, "Hotel 86", 98, "Pais 86" },
                    { 87, true, "Descripcion 87", 0.48511438887143454, 0.95815288754513916, "Hotel 87", 51, "Pais 87" },
                    { 88, true, "Descripcion 88", 0.28811460321449645, 0.93470936744226851, "Hotel 88", 64, "Pais 88" },
                    { 89, true, "Descripcion 89", 0.50905357395614625, 0.66961487277125786, "Hotel 89", 27, "Pais 89" },
                    { 90, true, "Descripcion 90", 0.041418729644830177, 0.88948771839511731, "Hotel 90", 21, "Pais 90" },
                    { 91, true, "Descripcion 91", 0.68306803597870092, 0.031370782838044398, "Hotel 91", 96, "Pais 91" },
                    { 92, true, "Descripcion 92", 0.61181080078287653, 0.8715828567312548, "Hotel 92", 25, "Pais 92" },
                    { 93, true, "Descripcion 93", 0.64362965214042234, 0.57872612058688699, "Hotel 93", 14, "Pais 93" },
                    { 94, true, "Descripcion 94", 0.62457804096566683, 0.91892536583840279, "Hotel 94", 5, "Pais 94" },
                    { 95, true, "Descripcion 95", 0.89747725102334919, 0.76264942334264119, "Hotel 95", 70, "Pais 95" },
                    { 96, true, "Descripcion 96", 0.5049880718989429, 0.51662030299867279, "Hotel 96", 28, "Pais 96" },
                    { 97, true, "Descripcion 97", 0.14434964748164436, 0.26358668512491146, "Hotel 97", 46, "Pais 97" },
                    { 98, true, "Descripcion 98", 0.356444498073617, 0.26050099856368081, "Hotel 98", 58, "Pais 98" },
                    { 99, true, "Descripcion 99", 0.21686591306847647, 0.31228798139474456, "Hotel 99", 50, "Pais 99" },
                    { 100, true, "Descripcion 100", 0.80601437778788931, 0.3384511947194736, "Hotel 100", 39, "Pais 100" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Apellidos", "Direccion", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "apellido 1", "Direccion 1", "Email@dominio.com 1", "usuario 1" },
                    { 2, "apellido 2", "Direccion 2", "Email@dominio.com 2", "usuario 2" },
                    { 3, "apellido 3", "Direccion 3", "Email@dominio.com 3", "usuario 3" },
                    { 4, "apellido 4", "Direccion 4", "Email@dominio.com 4", "usuario 4" },
                    { 5, "apellido 5", "Direccion 5", "Email@dominio.com 5", "usuario 5" },
                    { 6, "apellido 6", "Direccion 6", "Email@dominio.com 6", "usuario 6" },
                    { 7, "apellido 7", "Direccion 7", "Email@dominio.com 7", "usuario 7" },
                    { 8, "apellido 8", "Direccion 8", "Email@dominio.com 8", "usuario 8" },
                    { 9, "apellido 9", "Direccion 9", "Email@dominio.com 9", "usuario 9" },
                    { 10, "apellido 10", "Direccion 10", "Email@dominio.com 10", "usuario 10" },
                    { 11, "apellido 11", "Direccion 11", "Email@dominio.com 11", "usuario 11" },
                    { 12, "apellido 12", "Direccion 12", "Email@dominio.com 12", "usuario 12" },
                    { 13, "apellido 13", "Direccion 13", "Email@dominio.com 13", "usuario 13" },
                    { 14, "apellido 14", "Direccion 14", "Email@dominio.com 14", "usuario 14" },
                    { 15, "apellido 15", "Direccion 15", "Email@dominio.com 15", "usuario 15" },
                    { 16, "apellido 16", "Direccion 16", "Email@dominio.com 16", "usuario 16" },
                    { 17, "apellido 17", "Direccion 17", "Email@dominio.com 17", "usuario 17" },
                    { 18, "apellido 18", "Direccion 18", "Email@dominio.com 18", "usuario 18" },
                    { 19, "apellido 19", "Direccion 19", "Email@dominio.com 19", "usuario 19" },
                    { 20, "apellido 20", "Direccion 20", "Email@dominio.com 20", "usuario 20" },
                    { 21, "apellido 21", "Direccion 21", "Email@dominio.com 21", "usuario 21" },
                    { 22, "apellido 22", "Direccion 22", "Email@dominio.com 22", "usuario 22" },
                    { 23, "apellido 23", "Direccion 23", "Email@dominio.com 23", "usuario 23" },
                    { 24, "apellido 24", "Direccion 24", "Email@dominio.com 24", "usuario 24" },
                    { 25, "apellido 25", "Direccion 25", "Email@dominio.com 25", "usuario 25" },
                    { 26, "apellido 26", "Direccion 26", "Email@dominio.com 26", "usuario 26" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Apellidos", "Direccion", "Email", "Nombre" },
                values: new object[,]
                {
                    { 27, "apellido 27", "Direccion 27", "Email@dominio.com 27", "usuario 27" },
                    { 28, "apellido 28", "Direccion 28", "Email@dominio.com 28", "usuario 28" },
                    { 29, "apellido 29", "Direccion 29", "Email@dominio.com 29", "usuario 29" },
                    { 30, "apellido 30", "Direccion 30", "Email@dominio.com 30", "usuario 30" },
                    { 31, "apellido 31", "Direccion 31", "Email@dominio.com 31", "usuario 31" },
                    { 32, "apellido 32", "Direccion 32", "Email@dominio.com 32", "usuario 32" },
                    { 33, "apellido 33", "Direccion 33", "Email@dominio.com 33", "usuario 33" },
                    { 34, "apellido 34", "Direccion 34", "Email@dominio.com 34", "usuario 34" },
                    { 35, "apellido 35", "Direccion 35", "Email@dominio.com 35", "usuario 35" },
                    { 36, "apellido 36", "Direccion 36", "Email@dominio.com 36", "usuario 36" },
                    { 37, "apellido 37", "Direccion 37", "Email@dominio.com 37", "usuario 37" },
                    { 38, "apellido 38", "Direccion 38", "Email@dominio.com 38", "usuario 38" },
                    { 39, "apellido 39", "Direccion 39", "Email@dominio.com 39", "usuario 39" },
                    { 40, "apellido 40", "Direccion 40", "Email@dominio.com 40", "usuario 40" },
                    { 41, "apellido 41", "Direccion 41", "Email@dominio.com 41", "usuario 41" },
                    { 42, "apellido 42", "Direccion 42", "Email@dominio.com 42", "usuario 42" },
                    { 43, "apellido 43", "Direccion 43", "Email@dominio.com 43", "usuario 43" },
                    { 44, "apellido 44", "Direccion 44", "Email@dominio.com 44", "usuario 44" },
                    { 45, "apellido 45", "Direccion 45", "Email@dominio.com 45", "usuario 45" },
                    { 46, "apellido 46", "Direccion 46", "Email@dominio.com 46", "usuario 46" },
                    { 47, "apellido 47", "Direccion 47", "Email@dominio.com 47", "usuario 47" },
                    { 48, "apellido 48", "Direccion 48", "Email@dominio.com 48", "usuario 48" },
                    { 49, "apellido 49", "Direccion 49", "Email@dominio.com 49", "usuario 49" },
                    { 50, "apellido 50", "Direccion 50", "Email@dominio.com 50", "usuario 50" },
                    { 51, "apellido 51", "Direccion 51", "Email@dominio.com 51", "usuario 51" },
                    { 52, "apellido 52", "Direccion 52", "Email@dominio.com 52", "usuario 52" },
                    { 53, "apellido 53", "Direccion 53", "Email@dominio.com 53", "usuario 53" },
                    { 54, "apellido 54", "Direccion 54", "Email@dominio.com 54", "usuario 54" },
                    { 55, "apellido 55", "Direccion 55", "Email@dominio.com 55", "usuario 55" },
                    { 56, "apellido 56", "Direccion 56", "Email@dominio.com 56", "usuario 56" },
                    { 57, "apellido 57", "Direccion 57", "Email@dominio.com 57", "usuario 57" },
                    { 58, "apellido 58", "Direccion 58", "Email@dominio.com 58", "usuario 58" },
                    { 59, "apellido 59", "Direccion 59", "Email@dominio.com 59", "usuario 59" },
                    { 60, "apellido 60", "Direccion 60", "Email@dominio.com 60", "usuario 60" },
                    { 61, "apellido 61", "Direccion 61", "Email@dominio.com 61", "usuario 61" },
                    { 62, "apellido 62", "Direccion 62", "Email@dominio.com 62", "usuario 62" },
                    { 63, "apellido 63", "Direccion 63", "Email@dominio.com 63", "usuario 63" },
                    { 64, "apellido 64", "Direccion 64", "Email@dominio.com 64", "usuario 64" },
                    { 65, "apellido 65", "Direccion 65", "Email@dominio.com 65", "usuario 65" },
                    { 66, "apellido 66", "Direccion 66", "Email@dominio.com 66", "usuario 66" },
                    { 67, "apellido 67", "Direccion 67", "Email@dominio.com 67", "usuario 67" },
                    { 68, "apellido 68", "Direccion 68", "Email@dominio.com 68", "usuario 68" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Apellidos", "Direccion", "Email", "Nombre" },
                values: new object[,]
                {
                    { 69, "apellido 69", "Direccion 69", "Email@dominio.com 69", "usuario 69" },
                    { 70, "apellido 70", "Direccion 70", "Email@dominio.com 70", "usuario 70" },
                    { 71, "apellido 71", "Direccion 71", "Email@dominio.com 71", "usuario 71" },
                    { 72, "apellido 72", "Direccion 72", "Email@dominio.com 72", "usuario 72" },
                    { 73, "apellido 73", "Direccion 73", "Email@dominio.com 73", "usuario 73" },
                    { 74, "apellido 74", "Direccion 74", "Email@dominio.com 74", "usuario 74" },
                    { 75, "apellido 75", "Direccion 75", "Email@dominio.com 75", "usuario 75" },
                    { 76, "apellido 76", "Direccion 76", "Email@dominio.com 76", "usuario 76" },
                    { 77, "apellido 77", "Direccion 77", "Email@dominio.com 77", "usuario 77" },
                    { 78, "apellido 78", "Direccion 78", "Email@dominio.com 78", "usuario 78" },
                    { 79, "apellido 79", "Direccion 79", "Email@dominio.com 79", "usuario 79" },
                    { 80, "apellido 80", "Direccion 80", "Email@dominio.com 80", "usuario 80" },
                    { 81, "apellido 81", "Direccion 81", "Email@dominio.com 81", "usuario 81" },
                    { 82, "apellido 82", "Direccion 82", "Email@dominio.com 82", "usuario 82" },
                    { 83, "apellido 83", "Direccion 83", "Email@dominio.com 83", "usuario 83" },
                    { 84, "apellido 84", "Direccion 84", "Email@dominio.com 84", "usuario 84" },
                    { 85, "apellido 85", "Direccion 85", "Email@dominio.com 85", "usuario 85" },
                    { 86, "apellido 86", "Direccion 86", "Email@dominio.com 86", "usuario 86" },
                    { 87, "apellido 87", "Direccion 87", "Email@dominio.com 87", "usuario 87" },
                    { 88, "apellido 88", "Direccion 88", "Email@dominio.com 88", "usuario 88" },
                    { 89, "apellido 89", "Direccion 89", "Email@dominio.com 89", "usuario 89" },
                    { 90, "apellido 90", "Direccion 90", "Email@dominio.com 90", "usuario 90" },
                    { 91, "apellido 91", "Direccion 91", "Email@dominio.com 91", "usuario 91" },
                    { 92, "apellido 92", "Direccion 92", "Email@dominio.com 92", "usuario 92" },
                    { 93, "apellido 93", "Direccion 93", "Email@dominio.com 93", "usuario 93" },
                    { 94, "apellido 94", "Direccion 94", "Email@dominio.com 94", "usuario 94" },
                    { 95, "apellido 95", "Direccion 95", "Email@dominio.com 95", "usuario 95" },
                    { 96, "apellido 96", "Direccion 96", "Email@dominio.com 96", "usuario 96" },
                    { 97, "apellido 97", "Direccion 97", "Email@dominio.com 97", "usuario 97" },
                    { 98, "apellido 98", "Direccion 98", "Email@dominio.com 98", "usuario 98" },
                    { 99, "apellido 99", "Direccion 99", "Email@dominio.com 99", "usuario 99" },
                    { 100, "apellido 100", "Direccion 100", "Email@dominio.com 100", "usuario 100" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdHotel",
                table: "Reserva",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdUsuario",
                table: "Reserva",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
