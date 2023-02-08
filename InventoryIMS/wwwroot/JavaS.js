$("#dropdown").change(function () {
    var selectedValue = $(this).val();

    $.ajax({
        url: "/ControllerName/GetTextboxValue",
        type: "POST",
        data: { dropdownValue: selectedValue },
        success: function (result) {
            $("#textbox").val(result.textboxValue);
        }
    });
});