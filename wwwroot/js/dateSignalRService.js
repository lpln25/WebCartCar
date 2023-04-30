var con = new signalR.HubConnectionBuilder()
    .withUrl("/conhub")
    .build();

con.on("getSearchResultCartcar", getSearchResultCartcar);
con.on("getSearchResultInfractionCar", getSearchResultInfractionCar);

function showCartcar(r) {
    $("#tableCartcar").append("<tr><td>" + r.ownerName + "</td><td>"
        + r.nationalCode + "</td><td>" + r.fathername + "</td><td>" + r.vin + "</td><td>"
        + r.modelCar + "</td><td>" + r.systemCar + "</td><td>" + r.tip + "</td><td>"
        + r.color + "</td><td>" + r.dateCreated + "</td><td>" + r.copacity + "</td><td>"
        + r.engineNumber + "</td><td>" + r.chassisNumber + "</td><td>" + r.serialNumber + "</td></tr>")
}

function showInfractionCar(i) {
    $("#tableInfractionCar").append("<tr><td>" + i.code + "</td><td>" + i.infraction + "</td><td>" + i.price1 + "</td><td>" + i.price2 + "</td><td>" + i.price3 + "</td></tr>");
}

function getSearchResultCartcar(result) {
    debugger;
    // id, ownerName, nationalCode, fathername, vin, modelCar, fuelType, systemCar, tip, color, dateCreated, copacity, engineNumber, chassisNumber, serialNumber
    $("#tableCartcar").html('');
    showCartcar(result);
}


function getSearchResultInfractionCar(infractionCar) {
    debugger;
    // id, code, infraction, price1, price2, price3
    $("#tableInfractionCar").html('');
    showInfractionCar(infractionCar);
}


function onLoadCartcarClick(part1, part2, part3, part4) {
    //debugger;
    // part1: string, part2: int, part3: sting, part4: string

    // invoke
    con.invoke("SearchTagcarToCartcar", part1, part2, part3, part4);
}

function onLoadInfractionClick(code) {
    // code: long
    con.invoke("SearchResultInfractionCar", code);
}

function init() {
    con.start();
}

$(document).ready(function () {
    init();
});