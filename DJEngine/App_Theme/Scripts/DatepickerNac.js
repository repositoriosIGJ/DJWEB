$(document).ready(function() {
    $(".datepickernac").datepicker({
        changeMonth: true,
        changeYear: true,
        //yearRange: '1950:2013', // specifying a hard coded year range
        yearRange: "-140:+0",
        maxDate: "+0d", showAnim: "fold", buttonImageOnly: true, buttonImage: "./App_Theme/Imagenes/btndatepicker.gif", showOn: 'button'
    });
});
