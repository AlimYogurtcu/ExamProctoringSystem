$(window).on("load", function (e) {
    $("body").removeClass("preload");
});

$(function () {
    $("#signinModal").modal("show");
});

$("#signinModal").modal({
    backdrop: "static",
    keyboard: false,
});

//Textarea'da Shift+Enter yeni satır oluşturması, sadece Enter'a basılırsa mesaj gönderilsin diye
$("#roomID").keydown(function (e) {
    if (e.keyCode == 13 && !e.shiftKey) {
        e.preventDefault();
    }
    if (e.keyCode == 13 && e.shiftKey) {
        e.preventDefault();
    }
});
$("#roomPassword").keydown(function (e) {
    if (e.keyCode == 13 && !e.shiftKey) {
        e.preventDefault();
    }
    if (e.keyCode == 13 && e.shiftKey) {
        e.preventDefault();
    }
});

function copyToClipboard(id) {
    document.getElementById("copyRoomInformaiton").style.backgroundColor =
        "green"
    setTimeout(function () {
        document.getElementById("copyRoomInformaiton").style.backgroundColor =
            "blue";
    }, 250);
    var text = document.getElementById(id).innerText;
    var temp = document.createElement("textarea");
    document.body.appendChild(temp);
    temp.value = text;
    temp.select();
    document.execCommand("copy");
    document.body.removeChild(temp);
}

//Bildirim sesi fonksiyonu
function notification() {
    var audio = document.getElementById("notificationAudio");
    audio.play();
}

function clearAllAlert() {
    document.getElementById("clearAllAlert").style.backgroundColor =
        "green"
    setTimeout(function () {
        document.getElementById("clearAllAlert").style.backgroundColor =
            "burlywood";
    }, 250);
    document.getElementById("toast-container").remove();
}


       function fullscreen() {
       if ((document.fullScreenElement && document.fullScreenElement !== null) ||
           (!document.mozFullScreen && !document.webkitIsFullScreen)) {
           if (document.documentElement.requestFullScreen) {
               document.documentElement.requestFullScreen();
           } else if (document.documentElement.mozRequestFullScreen) {
               document.documentElement.mozRequestFullScreen();
           } else if (document.documentElement.webkitRequestFullScreen) {
               document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
           }
       } else {
           if (document.cancelFullScreen) {
               document.cancelFullScreen();
           } else if (document.mozCancelFullScreen) {
               document.mozCancelFullScreen();
           } else if (document.webkitCancelFullScreen) {
               document.webkitCancelFullScreen();
           }
       }
     }