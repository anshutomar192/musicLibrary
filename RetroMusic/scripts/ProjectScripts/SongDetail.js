function SaveDetail() {
    debugger;
    var email = $.trim($("#txtEmail").val());
    var songName = $.trim($("#songNameSpan").text());
    if ($.trim(email) == "" || $.trim(email) === undefined) {
        var msg = "please enter email address";
        $('#error').html(msg);
    }
    else {
        $.ajax({
            url: "/Song/UpdatePurchase",
            type: "POST",
            data: { songName: songName, email: email },
            cache: false,
            async: true,
            success: function (data) {
                debugger;
                $('#user_content').html(data);

            },
        });
    }
}