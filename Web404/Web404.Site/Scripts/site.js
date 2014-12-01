$(function () {

	sys.start();
	
});

var sys = new function () {
	var tags;

	var _speed = 750;
	var open_icon = "glyphicon-collapse-down";
	var close_icon = "glyphicon-collapse-up";

	this.start = function() {
		$(".sys-ajax").on("click", sys.ajaxLoad);
		$(".sys-panel").on("open", function () { $(this).find(".continue").hide(); });
		$(".sys-panel").on("close", function () { $(this).find(".continue").show(); });

		this.setupTagGraph();
		updateSection($("body"));
	};

	this.ajaxLoad = function (evnt) {
		var el = $(this);
		var url = el.attr("href");
		var target = findTarget(el);
		

		$.ajax(url)
		.done(function (r)
		{
			var html = $(r);
			target.html(html);
			updateSection(target);

			el.unbind("click");
			el.bind("click", collapse);

			var icon_loc = el.data("icon-element");
			if (icon_loc) el.find(icon_loc).removeClass(open_icon).addClass(close_icon);
			target.trigger("open");
		});
		
		
		return false;
	};

	var collapse = function (evnt) {
		var el = $(this);
		var target = findTarget(el);
		target.empty();

		el.unbind("click");
		el.bind("click", sys.ajaxLoad);

		var icon_loc = el.data("icon-element");
		if (icon_loc)  el.find(icon_loc).removeClass(close_icon).addClass(open_icon);

		target.trigger("close");
		return false;
	}

	var findTarget = function (el) {
		var target = el.parents(".sys-panel").find(".sys-target");
		//TODO: Explicit target
		return target;
	}

	this.setupTagGraph = function() 
	{
		//alert("test");


		tags = 
			[ "C#", "d3.js", "ASP.Net MVC", "Javascript", "jquery", "tools", "projects",
			"LINQ", "off-topic", "Metacode", "T4","Rant","SQL","Tutorials", "Azure"]
			.map(function (d) { return { text: d, size:  Math.random() * 20 }});
		
		drawTagGraph();
		$(window).resize(drawTagGraph);

	};

	var drawTagGraph = 	function()
	{
		
		var el = $("#tags");
		el.width(el.parent().width());

		var w = el.width();
		var h = el.height();

		var w_bar = w / tags.length;

		var x = d3.scale.linear().domain([0, tags.length]).range([0, w]);
		var y = d3.scale.linear().domain([0, d3.max(tags, function (e) { return e.size; })]).range([0, h - 10]);

		var svg = d3.select("#tags");

		var groups = svg.selectAll("g.tag")
		.data(tags)
		.enter()
		.append("a")
		.attr("xlink:href", function (d, i) { return "/tags/" + d.text; })
		.append("g")
		.attr("class", "tag");


		groups
		.append("rect")
		.attr("height", 0)
		.attr("y", h)
		.transition()
		.delay(function (d, i) { return i * 100})
		.duration(1000)
		.attr("height", function (d, i) { return y(d.size); })
		.attr("y", function (d, i) { return h - y(d.size); });

		groups
		.append("text")
		.attr("opacity", 0)
		.attr("x", 0)
		.attr("y", h)
		.attr("dx", 10)
		.attr("dy", function () { return w_bar / 2 + Math.min(w_bar * .80, 12) / 2; })
		.transition()
		.delay(function (d, i) { return i * 150 })
		.duration(1000)
		.attr("transform", function (e, i) { return "rotate(-90, 0, " + h + ")" })
		.attr("opacity", 1)
		.text(function (e) { return e.text; });


		var gtags =
		svg.selectAll("g.tag").attr("transform", function (d, i) { return "translate( " + w_bar * i + ", 0)"; });
		gtags.select("rect").attr("width", function () { return w_bar * .90 });
		gtags.select("text")
		.attr("dy", function () { return w_bar / 2 + Math.min(w_bar * .80, 12) / 2; })
		.attr("font-size", function () { return Math.min(w_bar * .80, 12) + "px" });
	}

	var updateSection = function(el)
	{
		Rainbow.color(el);

		el.find(".html-demo").each(function () {
			var html = $(this).text();
			//console.log("demo");
			//console.log(html);
			//$(this).text(html);

			$("<div class='sys-demo'></div>").html(html).insertAfter($(this));
		});

		el.find(".js-demo").each(function () {
			var text = $(this).text();
			console.log(text);
			var test = function () { $.globalEval(text); };
		
			$("<button>Run</button>").insertAfter($(this)).click(test);
			//test();
		});

		
		
		
	}

	
};