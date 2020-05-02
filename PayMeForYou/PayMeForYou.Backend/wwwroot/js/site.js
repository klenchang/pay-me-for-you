// Get the Sidebar
var mySidebar = document.getElementById("mySidebar");

// Get the DIV with overlay effect
var overlayBg = document.getElementById("myOverlay");

// Toggle between showing and hiding the sidebar, and add overlay effect
function switchMenu() {
    var display = mySidebar.style.display === 'block' ? 'none' : 'block';
    mySidebar.style.display = display;
    overlayBg.style.display = display;
}

// Show and hide side bar item
function switchSideBarItemDetail(trigger) {
    var x = trigger.nextElementSibling;
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
        trigger.className += " w3-green";
        trigger.innerHTML = trigger.innerHTML.replace("keyboard_arrow_up", "keyboard_arrow_down");
    } else {
        x.className = x.className.replace(" w3-show", "");
        trigger.className = trigger.className.replace(" w3-green", "");
        trigger.innerHTML = trigger.innerHTML.replace("keyboard_arrow_down", "keyboard_arrow_up");
    }
}

$(".partial-load").click(() => {
    partialLoad(true);
});

function partialLoad(isSwitch) {
    event.preventDefault();
    var url = $(event.target).attr("href");
    $('#divMainBody').load(url);
    if (isSwitch && $("#btnMenu").css("display") === 'block') {
        switchMenu();
    }
    document.documentElement.scrollTop = 0;
}

function submitAjax(form, successEvent, errorEvent) {
    event.preventDefault();
    $.ajax({
        url: form.attr('action'),
        type: form.attr('method'),
        data: form.serialize(),
        success: function(response) {
            successEvent(response);
        },
        error: function(response) {
            errorEvent(response);
        }
    });
}