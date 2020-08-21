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

var ajaxUtility = {
    formSubmit: function (form, successEvent, errorEvent) {
        event.preventDefault();
        this.send(form.attr('action'), form.attr('method'), form.serialize(), successEvent, errorEvent);
    },
    send: (url, method, data, successEvent, errorEvent) => {
        $.ajax({
            url: url,
            type: method,
            data: data,
            success: function (response) {
                successEvent(response);
            },
            error: function (response) {
                errorEvent(response);
            }
        });
    }
}

function searchTableData() {
    var container = $("#searchResult");
    var url = container.data("path");
    var pageSize = $("#pageSize").length != 0 ? $("#pageSize").val() : 10;
    var pageIndex = $("#pageIndex").length != 0 ? $("#pageIndex").val() : 1;
    var pagenationSetting = { "PageSize": pageSize, "PageIndex": pageIndex };
    ajaxUtility.send(url, "get", pagenationSetting, function (response) { container.html(response) }, function (response) { console.log(response) });
}