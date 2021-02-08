

$(document).ready(function () {
    var table = $('#myTable').DataTable({
        "ajax": {
            "url": "/Song/GetLibraries",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
                  { "data": "SongId", "autoWidth": true },
                  { "data": "SongName", "autoWidth": true },
                  { "data": "AlbumName", "autoWidth": true },
                  { "data": "Language", "autoWidth": true },
                  { "data": "SingerName", "autoWidth": true }

        ]
    });

    $('#myTable tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        $.ajax({
            url: "/Song/GetLibraryDetail",
            type: "GET",
            data: { SongId: data.SongId },
            cache: false,
            async: true,
            success: function (data) {
                $('#user_content').html(data);
            },
            fail: function (xhr, textStatus, errorThrown) {

            }

        });
    });
});