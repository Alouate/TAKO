let socket = io();
let msg = {
    teamID: "",
    id: "",
};
let cooldown = 500;

 $(document).ready(function () {
    let id = Date.now();
    console.log("connected, id: " + id);

    msg.id = id;

    if ($('body').hasClass("redTeam")) msg.teamID = 0;
    if ($('body').hasClass("blueTeam")) msg.teamID = 1;

    socket.emit("spawn", msg);
})

$('#red').click(function () {
    if (!$("#red").hasClass("button-inactive")) {
        socket.emit('redScore', msg);
        pauseButton("red");
        animateSquid("red");
    }
});

$('#blue').click(function () {
    if (!$("#blue").hasClass("button-inactive")) { 
          socket.emit('blueScore', msg);
        pauseButton("blue");
        animateSquid("blue");
    }
});

function pauseButton(btnName) {
    let id = "#" + btnName;
    $(id).addClass("button-inactive");
    setTimeout(
        function() {
            $(id).removeClass("button-inactive");
        },
        cooldown
    )
}

function animateSquid(btnName) {
    let src = "";

    if (btnName == "red") src = "redsquid";
    if (btnName == "blue") src = "bluesquid";

    $(".squid").attr("src", src + "2");
    $(".squid").addClass("squid-active");
    setTimeout(function() {
        $(".squid").attr("src", src + "1");
        $(".squid").removeClass("squid-active");
    }, cooldown);

}

function randomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min);
}