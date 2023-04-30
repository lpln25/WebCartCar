// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function datepicker() {
    var customOptions = {

        placeholder: "روز / ماه / سال"
        , buttonsColor: "red"
        , twodigit: false
        , closeAfterSelect: false
        , buttonsColor: "blue"
        , forceFarsiDigits: true
        , markToday: true
        , markHolidays: true
        , highlightSelectedDay: true
        , sync: true,
        
        //, gotoToday: true
    }
    kamaDatepicker('DateDone', customOptions);
}


function init() {
    datepicker();

}

$(document).ready(init());
