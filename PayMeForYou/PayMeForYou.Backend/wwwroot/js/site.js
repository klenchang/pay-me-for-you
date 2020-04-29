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
        x.previousElementSibling.className += " w3-green";
    } else {
        x.className = x.className.replace(" w3-show", "");
        x.previousElementSibling.className =
            x.previousElementSibling.className.replace(" w3-green", "");
    }
}

$(".partial-load").click(event => {
    event.preventDefault();
    var url = $(event.target).attr("href");
    $('#divMainBody').load(url);
    if ($("#btnMenu").css("display") === 'block') {
        switchMenu();
    }
});

function submitAjax(form, successEvent, errorEvent) {
    event.preventDefault();
    $.ajax({
        url: form.attr('action'),
        type: form.attr('method'),
        data: form.serialize(), // data to be submitted
        success: function(response) {
            successEvent(response); // do what you like with the response
        },
        error: function(response) {
            errorEvent(response);
        }
    });
}