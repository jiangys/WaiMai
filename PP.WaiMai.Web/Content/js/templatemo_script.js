
jQuery(function(){
    $ = jQuery ;
    //main menu
    $("#templatemo_banner_menu ul").singlePageNav({offset: $('#templatemo_banner_menu').outerHeight()});
    //banner slide
    $('.banner').unslider({fluid: true});
    $(window).on("load scroll resize", function(){
        banner_height = ($(document).width()/1920) * 500;
        $('.banner').height(banner_height);
        $('.banner ul li').height(banner_height);
        if(banner_height > 250){
            caption_margin_top = (banner_height-300)/2;
            $('.banner .slide_caption:hidden').show();
            $('.banner .slide_caption').css({"margin-top":caption_margin_top});
        }else{
            $('.banner .slide_caption').hide();
        }
        $("#templatemo_banner_slide > ul > li").css({"background-size":"cover"});
    });
    //event
    $(".event_box_img").load(function(){
        img_height = $(this).height();
        $(this).parent(".event_box_wap").height(img_height);
    });
    $(window).on("load resize", function(){
        img_height = $(".event_box_img").height();
        if($(window).width()>550){
            $(".event_box_wap").height(img_height);
            $(".event_box_wap").each(function(){
                total_height = $(this).children(".event_box_caption").outerHeight();
                header_height = $(this).children(".event_box_caption").children("h1").outerHeight();
                admin_height = $(this).children(".event_box_caption").children("p").eq(0).outerHeight();
                paragraph_height = $(this).children(".event_box_caption").children("p").eq(1).outerHeight();
                hide_paragraph_height = header_height + admin_height + 10 ;
                $(this).children(".event_box_caption").css({"top": "-" + hide_paragraph_height + "px"});
            });
        }else{
            $(".event_box_wap").height(img_height);
            $(".event_box_wap").each(function(){
                total_height = $(this).children(".event_box_caption").outerHeight();
                header_height = $(this).children(".event_box_caption").children("h1").outerHeight();
                admin_height = $(this).children(".event_box_caption").children("p").eq(0).outerHeight();
                paragraph_height = $(this).children(".event_box_caption").children("p").eq(1).outerHeight();
                hide_paragraph_height = header_height + admin_height + 10 ;
                $(this).height(total_height+img_height);
                $(this).children(".event_box_caption").css({"top": "0px"});
            });
        }
    });
    $(".event_box_wap").hover(function(){
        if($(window).width()>550){
            total_height = $(this).children(".event_box_caption").outerHeight();
            header_height = $(this).children(".event_box_caption").children("h1").outerHeight();
            admin_height = $(this).children(".event_box_caption").children("p").eq(0).outerHeight();
            paragraph_height = $(this).children(".event_box_caption").children("p").eq(1).outerHeight();
            hide_paragraph_height = header_height + admin_height + paragraph_height + 10 ;
            $(this).children(".event_box_caption").stop().animate({"top": "-" + hide_paragraph_height + "px"});
        }
    },function(){
        if($(window).width()>550){
            total_height = $(this).children(".event_box_caption").outerHeight();
            header_height = $(this).children(".event_box_caption").children("h1").outerHeight();
            admin_height = $(this).children(".event_box_caption").children("p").eq(0).outerHeight();
            paragraph_height = $(this).children(".event_box_caption").children("p").eq(1).outerHeight();
            hide_paragraph_height = header_height + admin_height + 10 ;
            $(this).children(".event_box_caption").stop().animate({"top": "-" + hide_paragraph_height + "px"});
        }
    });

    //timeline
    $(window).on("load resize", function () {
        $.timeline_right_position_top = 0;
        $.timeline_old_right_position_top = 0;
        $.timeline_left_position_top = 0;
        $.timeline_old_left_position_top = 0;
        w_width = ($(window).width() > 1200) ? 1200 : $(window).width();
        $.timeline_item_width = (w_width - 50) / 2;
        $(".time_line_wap").each(function () {
            //if class name already exit remove
            $(this).children("a.left_timer").remove();
            $(this).children("a.right_timer").remove();
            $(this).removeClass("left_timeline");
            $(this).removeClass("right_timeline");
            if ($(window).width() < 970) {
                $("#templatemo_timeline .container-fluid").css({ "position": "absolute" });
                positon_left = $("#templatemo_timeline .container-fluid").position().left + 100;
                //put on right
                $(this).css({
                    'left': 70,
                    'top': $.timeline_right_position_top,
                    'width': $(window).width() - positon_left
                });
                $(this).addClass("right_timeline");
                $.timeline_old_right_position_top = $.timeline_right_position_top;
                $.timeline_right_position_top = $.timeline_right_position_top + $(this).outerHeight() + 40;
                $(this).prepend("<a href=\"/tucao\" class=\"right_timer\"><span class=\"glyphicon glyphicon-time\"></span></a>");
                $(this).children("a.right_timer").css({ left: -86, width: 60, });
            } else if ($.timeline_left_position_top == 0) {
                $("#templatemo_timeline .container-fluid").css({ "position": "relative" });
                //put on left
                $(this).css({
                    'left': 0,
                    'top': 0,
                    'width': $.timeline_item_width - 50
                });
                $(this).addClass("left_timeline");
                $.timeline_old_left_position_top = $.timeline_left_position_top;
                $.timeline_left_position_top = $.timeline_left_position_top + $(this).outerHeight() + 40;
                $(this).prepend("<a href=\"/tucao\" class=\"left_timer\"><span class=\"glyphicon glyphicon-time\"></span></a>");
                $(this).children("a.left_timer").css({ left: $.timeline_item_width - 50, });
            } else if ($.timeline_right_position_top < $.timeline_left_position_top) {
                $("#templatemo_timeline .container-fluid").css({ "position": "relative" });
                $.timeline_right_position_top = ($.timeline_old_left_position_top + 40) < $.timeline_right_position_top ? $.timeline_right_position_top : $.timeline_right_position_top + 40;
                //put on right
                $(this).css({
                    'left': $.timeline_item_width + 79,
                    'top': $.timeline_right_position_top,
                    'width': $.timeline_item_width - 50
                });
                $(this).addClass("right_timeline");
                $.timeline_old_right_position_top = $.timeline_right_position_top;
                $.timeline_right_position_top = $.timeline_right_position_top + $(this).outerHeight() + 40;
                $(this).prepend("<a href=\"/tucao\" class=\"right_timer\"><span class=\"glyphicon glyphicon-time\"></span></a>");
                $(this).children("a.right_timer").css({ left: -99, });
            } else {
                $("#templatemo_timeline .container-fluid").css({ "position": "relative" });
                $.timeline_left_position_top = ($.timeline_old_right_position_top + 40) < $.timeline_left_position_top ? $.timeline_left_position_top : $.timeline_left_position_top + 40;
                //put on left
                $(this).css({
                    'left': 0,
                    'top': $.timeline_left_position_top,
                    'width': $.timeline_item_width - 50
                });
                $(this).addClass("left_timeline");
                $.timeline_old_left_position_top = $.timeline_left_position_top;
                $.timeline_left_position_top = $.timeline_left_position_top + $(this).outerHeight() + 40;
                $(this).prepend("<a href=\"/tucao\" class=\"left_timer\"><span class=\"glyphicon glyphicon-time\"></span></a>");
                $(this).children("a.left_timer").css({ left: $.timeline_item_width - 50, });
            }
            //calculate and define container height
            if ($.timeline_left_position_top > $.timeline_right_position_top) {
                $("#templatemo_timeline .container-fluid").height($.timeline_left_position_top - 40);
                $("#templatemo_timeline").height($.timeline_left_position_top + 200);
            } else {
                $("#templatemo_timeline .container-fluid").height($.timeline_right_position_top - 40);
                $("#templatemo_timeline").height($.timeline_right_position_top + 200);
            }
            $(this).fadeIn();
        });
    });
    //events
    //event
    //$(document).scroll(function(){
    //    document_top = $(document).scrollTop();
    //    event_wapper_top = $("#templatemo_events").position().top - $('#templatemo_banner_menu').outerHeight();
    //    if(document_top<event_wapper_top){
    //        event_animate_num = event_wapper_top - document_top;
    //        event_animate_alpha = (1/event_wapper_top)*(document_top);
    //        $("#templatemo_events .event_animate_left").css({'left': -event_animate_num,'opacity':event_animate_alpha});
    //        $("#templatemo_events .event_animate_right").css({'left':event_animate_num,'opacity':event_animate_alpha});
    //    }else{
    //        $("#templatemo_events .event_animate_left").css({'left': 0,'opacity':1});
    //        $("#templatemo_events .event_animate_right").css({'left':0,'opacity':1});
    //    }
    //}); 
});
