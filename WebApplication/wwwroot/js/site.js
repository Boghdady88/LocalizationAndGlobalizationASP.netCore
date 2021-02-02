function ChangeCulture(culture) {
    debugger
    $.get("/Home/SetLanguage", { culture: culture }, function (response) {
        window.location.reload();
    });
}
