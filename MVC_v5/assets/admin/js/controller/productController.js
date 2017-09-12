var product= {
    init:function() {
        product.registerEvents();
    },
    registerEvents:function() {
        $(".btn-images").off("click").on("click", function(e) {
            e.preventDefault();
            $("#imagesMananger").modal("show");
            $("#hidProdctID").val($(this).data("id"));
        });
        $("#btnChooImages").off("click").on("click", function(e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function(url) {
                $("imageList").append("<img src='"+url+"' width='50px' />");
            };
            finder.popup();
        });

    }
}
product.init();