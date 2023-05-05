var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

let redCount = 0;
let blueCount = 0;
let playerData = {
	teamID : 9,
	id: 0,
}

app.get('/jquery', function (req, res) {
	res.sendFile(__dirname + '/jquery-3.6.4.min.js');
});

app.get('/controls', function (req, res) {
	res.sendFile(__dirname + '/common/controls.js');
});

app.get('/styles', function (req, res) {
	res.sendFile(__dirname + '/common/styles.css');
});

app.get('/redbg', function (req, res) {
	res.sendFile(__dirname + '/red/img/bg.svg');
});

app.get('/redTako', function (req, res) {
	res.sendFile(__dirname + '/red/img/tako.svg');
});

app.get('/redQR', function (req, res) {
	res.sendFile(__dirname + '/red/img/recrute.svg');
});

app.get('/redsquid1', function (req, res) {
	res.sendFile(__dirname + '/red/img/redsquid1.png');
});

app.get('/redsquid2', function (req, res) {
	res.sendFile(__dirname + '/red/img/redsquid2.png');
});

app.get('/redcloud', function (req, res) {
	res.sendFile(__dirname + '/red/img/redclouds.svg');
});

app.get('/bluebg', function (req, res) {
	res.sendFile(__dirname + '/blue/img/bg.svg');
});

app.get('/blueTako', function (req, res) {
	res.sendFile(__dirname + '/blue/img/tako.svg');
});

app.get('/blueQR', function (req, res) {
	res.sendFile(__dirname + '/blue/img/recrute.svg');
});

app.get('/bluesquid1', function (req, res) {
	res.sendFile(__dirname + '/blue/img/bluesquid1.png');
});

app.get('/bluesquid2', function (req, res) {
	res.sendFile(__dirname + '/blue/img/bluesquid2.png');
});

app.get('/bluecloud', function (req, res) {
	res.sendFile(__dirname + '/blue/img/blueclouds.svg');
});

app.get('/button', function (req, res) {
	res.sendFile(__dirname + '/common/img/btn.svg');
});

app.get('/red', function (req, res) {	
	redCount++;
	res.sendFile(__dirname + '/red/index.html');
});

app.get('/blue', function (req, res) {
	blueCount++;
	res.sendFile(__dirname + '/blue/index.html');
});

app.get('/start', function (req, res) {

	let team = determineTeam();

	if (team == 0) {
		redCount++;
		playerData.teamID = 0;
		res.sendFile(__dirname + '/red/index.html');
	}
	if (team == 1) {
		blueCount++;
		playerData.teamID = 1;
		res.sendFile(__dirname + '/blue/index.html');
	}

	console.log(playerData);
});

app.get('/resetscores', function (req, res) {
	blueCount = 0;
	redCount = 0;
	res.sendFile(__dirname + '/blue/img/tako.svg');
});

io.on('connection', function (socket) {

	// socket.on('id', function (msg) {
	// 	console.log(playerData);
	// 	io.emit("spawn", playerData);
	// });

	socket.on('spawn', function (msg) {
		io.emit("spawn", msg);
		console.log("Spawn ",msg);
	});

	socket.on('redScore', function (msg) {
		io.emit("points", msg);
		console.log(msg);
	});

	socket.on('blueScore', function (msg) {
		//score--;	
		io.emit("points", msg);
		console.log(msg);
	});

});

http.listen(3000, function () {
	console.log('listening on *:3000');
});

function determineTeam() {
	let givenTeam;
	if (redCount < blueCount)  givenTeam = 0;
	if (blueCount < redCount)  givenTeam = 1;
	if (blueCount == redCount) givenTeam = Math.round(Math.random());
	return givenTeam;
}