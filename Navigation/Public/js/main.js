$(document).ready(function() {


    $.validate({

        modules: 'location, date, security, file'
       

    });


    $("#CategorySearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/GetCategories",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function(data) {
                    response($.map(data,
                        function(item) {
                            return { label: item.Name, value: item.Name };
                        }));

                }
            });
        },
        messages: {
            noResults: "",
            results: function (count) {
                return count + (count > 1 ? ' results' : ' result ') + ' found';
            }
        }
    });

    $("#CitySearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/GetCities",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return { label: item.Name, value: item.Name };
                        }));

                }
            });
        },
        messages: {
            noResults: "",
            results: function (count) {
                return count + (count > 1 ? ' results' : ' result ') + ' found';
            }
        }
    });


    //$("#registerForm").submit(function(ev) {
    //    ev.preventDefault();

    //    $.ajax({
    //        url: $(this).attr("action"),
    //        type: $(this).attr("method"),
    //        dataType: "json",
    //        data: $(this).serialize(),
    //        success: function(responce) {
    //            console.log(responce);
    //        }

    //});
    //});


    //login omayibsa add Listing gire bilmesin
    $("#AddList").click(function() {

        $.ajax({
            url: "/Account/AccessLogin",
            type: "get",
            dataType: "json",
            success: function (responce) {
                if (responce.status === 404) {
                    $('#ModalLogReg').modal('show');
                }
                if (responce.status===200) {
                   window.location = responce.url;
                }
               
            }
        });

    });







    //mail yoxlama varsa register tekrar olmalidi
    $(window).on("load", function () {
     
        if (location.hash == '#registered') {
           
            $("#login").attr("area-selected", "false");
            $('#login').removeClass("active");
            $('#sign-up').addClass("active");
            $('#sign-up').addClass("show");
            $('#pills-home').removeClass("active");
            $('#pills-home').removeClass("show");
            $('#pills-profile').addClass("active");
            $('#pills-profile').addClass("show");
            $('#pills-home').remove("class", "show");
            $("#sign-up").attr("aria-selected", "true");
                $('#ModalLogReg').modal('show');
                

        } else {
            $("#sign-up").attr("aria-selected", "false");
            $('#sing-up').removeClass("active");
            $('#sing-up').removeClass("show");
            $('#pills-profile').removeClass("active");
            $('#pills-profile').removeClass("show");
        }



        });






    //categoriye gore servicelerin gelmesi
    $("#CategoryId").change(function() {
        var id = $(this).val();

        $("#servis").text('');

        $.ajax({
            url: "/Place/CategoryService",
            type: "get",
            data: {id:id},
            dataType: "json",
            success: function (responce) {
                
                $.each(responce,function(index,item) {
                    $("#servis").append(` <div class="col-md-4 responsive-wrap">
                                            <div class="md-checkbox">
                                                <input id="i${item.ServiceId}" name="${item.ServiceId}" type="checkbox">
                                                <label for="i${item.ServiceId}">${item.Name}</label>
                                            </div>
                                        </div>`
                    );
                });


            },
            error: function (response) {
                    console.log(response);
                }

        });



   
    });



    //form add
    
    var servis = [];


    //Categoriyaya gore place servislerin add olunmasi
    $(document).on("click", "#servis input", function () {


        if ($(this).prop("checked") === true) {
            servis.push($(this).attr("name"));

        } else {
            servis.splice($.inArray($(this).attr("name"), servis), 1);

        }
    });





    //Hefte gunlerinin yoxlanilmasi ve add olunmasi
    var WeekArr = [];
    var weekdays = ["monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"];

   
    
    


    $("#FormAdd").submit(function (ev) {
        ev.preventDefault();
       //cateqori secmese dayanacaq
        if ($('select[name="CategoryId"]').val() == 0) {
            toastr["error"]("Kateqoriya seçməmisiniz!");
           
            return false;
        }
        //seher secmese dayanacaq
        if ($('select[name="CityId"]').val() == 0) {
            toastr["error"]("Şəhər seçməmisiniz!");
           
            return false;
        }
        
       
       

        //var service = JSON.stringify(servis);
        var formdata = new FormData(); //FormData object
        var files = $("#files").get(0).files;
        //Iterating through each files selected in fileInput
        for (var i = 0; i < files.length; i++) {
            //Appending each file to FormData object
           
            formdata.append(files[i].name, files[i]);
        }


        var indexIncr = 0;
        $.each(weekdays,
            function (index, item) {
                indexIncr = index + 1;
                if ($('input[name=' + item + ']').is(":checked")) {

                    if ($('.week' + indexIncr + '1 option:selected').attr("value") === "Time" || $('.week' + indexIncr + '2 option:selected').attr("value") === "Time") {

                    } else {
                        
                        
                        var open = $('.week' + indexIncr + '1 option:selected').attr("value");
                        var close = $('.week' + indexIncr + '2 option:selected').attr("value");
                       
                        
                        WeekArr.push({
                            OpenHour: open,
                            CloseHour: close,
                            WeekNo: item
                        });
                       
                    }

                }


            });
       

       
        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            data: new FormData(this),
            traditional: true,
            dataType: "json",
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                if (data.status===404) {
                    toastr["error"](data.message);
                }

                var postData = {
                    servis: servis,
                    WeekArr: WeekArr,
                    placeId: data.placeId
                }
                if (data.status === 200) {
                    $.ajax({
                        type: "post",
                        url: "/place/create",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify(postData),
                        success: function (data) {
                           
                            if (data.status===200) {
                                toastr["success"](data.message);
                                setInterval(function () { window.location = data.url; }, 1000);
                            }
                           


                        }
                    });
                };


            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });

      
    });


   

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }


    $("#searchPlace").submit(function(ev) {
        ev.preventDefault();

        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",
            data: $(this).serialize(),
            success: function(data) {
                console.log(data);
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    });


});


