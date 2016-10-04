$("document").ready(function () {
    alert("JSCONNECTED");
    var Title = $("#Title").val();
    var Description = $("#Description").val();
    $("#submit").click(function () {
        alert("submited");
        $.ajax({
            url: "/Home/SetPost",
            type: "POST",
            dataType: "html",
            data: {Title,Description},
            success: function (data) {
                $("#result").html(data);
            }
        });
    });

});