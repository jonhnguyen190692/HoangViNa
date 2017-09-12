var user= {
    init:function() {
        user.registerEvents();
    },
    registerEvents: function() {
        $(".btn-active").off("click").on("click", function(e) {
            e.preventDefault();
            var id = parseInt($(this).data("id"));
            var btn = $(this);
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",
                success: function (responese) {
                    console.log(responese);
                    if (responese.status == true) {
                        btn.text("Kích hoạt");
                    } else {
                        btn.text("Khóa");

                    }
                }
            });
        });
    }
}
user.init();