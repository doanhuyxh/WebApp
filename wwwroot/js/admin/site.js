//chart 
var ctx1 = document.getElementById("chart-line").getContext("2d");

var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);

gradientStroke1.addColorStop(1, 'rgba(94, 114, 228, 0.2)');
gradientStroke1.addColorStop(0.2, 'rgba(94, 114, 228, 0.0)');
gradientStroke1.addColorStop(0, 'rgba(94, 114, 228, 0)');
new Chart(ctx1, {
    type: "line",
    data: {
        labels: ["Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            label: "Mobile apps",
            tension: 0.4,
            borderWidth: 0,
            pointRadius: 0,
            borderColor: "#5e72e4",
            backgroundColor: gradientStroke1,
            borderWidth: 3,
            fill: true,
            data: [50, 40, 300, 220, 500, 250, 400, 230, 500],
            maxBarThickness: 6

        }],
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
                display: false,
            }
        },
        interaction: {
            intersect: false,
            mode: 'index',
        },
        scales: {
            y: {
                grid: {
                    drawBorder: false,
                    display: true,
                    drawOnChartArea: true,
                    drawTicks: false,
                    borderDash: [5, 5]
                },
                ticks: {
                    display: true,
                    padding: 10,
                    color: '#fbfbfb',
                    font: {
                        size: 11,
                        family: "Open Sans",
                        style: 'normal',
                        lineHeight: 2
                    },
                }
            },
            x: {
                grid: {
                    drawBorder: false,
                    display: false,
                    drawOnChartArea: false,
                    drawTicks: false,
                    borderDash: [5, 5]
                },
                ticks: {
                    display: true,
                    color: '#ccc',
                    padding: 20,
                    font: {
                        size: 11,
                        family: "Open Sans",
                        style: 'normal',
                        lineHeight: 2
                    },
                }
            },
        },
    },
});

var win = navigator.platform.indexOf('Win') > -1;
if (win && document.querySelector('#sidenav-scrollbar')) {
    var options = {
        damping: '0.5'
    }
    Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
}

/*!
 * Loading overlay v1.0.0
 * https://github.com/windel07/loading-overlay.jquery
 *
 * Copyright (c) 2022 windel07
 */

(function ($) {
    $.fn.loadingOverlay = function (status = true, options = {}) {
        var settings = $.extend(
            {
                icon: null,
                backgroundColor: 'rgba(255,255,255,0.85)',
            },
            options
        );

        const loadingEl = $(this);
        const loadingOverlay = $(`<div class="loading__overlay"></div>`);
        const loadingIcon = $('<span class="loading__icon"></span>');

        loadingOverlay.css({
            backgroundColor: settings.backgroundColor || 'rgba(255,255,255,0.85)',
            position: ['HTML', 'BODY'].includes(loadingEl.prop('tagName'))
                ? 'fixed'
                : 'absolute',
        });

        if (settings.icon)
            loadingIcon.css({
                backgroundImage: `url(${settings.icon})`,
            });

        loadingIcon.appendTo(loadingOverlay);

        if (status) {
            loadingEl.addClass('loading').prepend(loadingOverlay);
        } else {
            loadingEl.removeClass('loading');

            if (loadingEl.children().eq(0).hasClass('loading__overlay'))
                loadingEl.children().eq(0).remove();
        }
    };
})(jQuery);
