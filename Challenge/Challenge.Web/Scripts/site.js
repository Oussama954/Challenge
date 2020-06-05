
$(function () {
    $("#AcceptedDatepicker").datepicker({
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        highlightWeek: true,
        showAnim: "scale",
        showOptions: {
            origin: ["top", "left"]
        }
    });
});