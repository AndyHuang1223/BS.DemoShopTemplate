// 等待文檔加載完成後再執行初始化
document.addEventListener("DOMContentLoaded", function () {

    bar()
    circle()
    line()
    smoothLine()
    scatter()
    radar()
});

function bar() {
    const bar = echarts.init(document.getElementById('bar'));

    bar.setOption({
        title: {
            text: 'ECharts 柱狀圖示例'
        },
        tooltip: {},
        xAxis: {
            data: ['襯衫', '羊毛衫', '雪紡衫', '褲子', '高跟鞋', '襪子']
        },
        yAxis: {},
        series: [
            {
                name: '銷量',
                type: 'bar',
                data: [5, 20, 36, 10, 10, 20]
            }
        ]
    });

}
function circle() {
    const circle = echarts.init(document.getElementById('circle'));

    circle.setOption({
        title: {
            text: 'ECharts 圓餅圖示例'
        },
        tooltip: {},
        series: [
            {
                name: '銷量',
                type: 'pie',
                radius: '55%', // 設置圓餅圖的半徑
                center: ['50%', '50%'], // 設置圓餅圖的中心位置
                data: [
                    { value: 5, name: '襯衫' },
                    { value: 20, name: '羊毛衫' },
                    { value: 36, name: '雪紡衫' },
                    { value: 10, name: '褲子' },
                    { value: 10, name: '高跟鞋' },
                    { value: 20, name: '襪子' }
                ]
            }
        ]
    });

}

function line() {
    const line = echarts.init(document.getElementById('line'));

    line.setOption({
        title: {
            text: 'ECharts 折線圖示例'
        },
        tooltip: {},
        xAxis: {
            data: ['襯衫', '羊毛衫', '雪紡衫', '褲子', '高跟鞋', '襪子']
        },
        yAxis: {},
        series: [
            {
                name: '銷量',
                type: 'line',
                data: [5, 20, 36, 10, 10, 20]
            }
        ]
    });

}

function smoothLine() {
    const smoothline = echarts.init(document.getElementById('smooth-line'));

    smoothline.setOption({
        title: {
            text: 'ECharts 曲線圖示例'
        },
        tooltip: {},
        xAxis: {
            data: ['襯衫', '羊毛衫', '雪紡衫', '褲子', '高跟鞋', '襪子']
        },
        yAxis: {},
        series: [
            {
                name: '銷量',
                type: 'line',
                smooth: true, // 設置為 true，使折線變成曲線
                data: [5, 20, 36, 10, 10, 20]
            }
        ]
    });

}

function scatter() {
    const scatter = echarts.init(document.getElementById('scatter'));

    scatter.setOption({
        title: {
            text: 'ECharts 散點圖示例'
        },
        xAxis: {},
        yAxis: {},
        series: [{
            symbolSize: 20,
            data: [
                [10.0, 8.04],
                [8.0, 6.95],
                [13.0, 7.58],
                [9.0, 8.81],
                [11.0, 8.33],
                [14.0, 9.96],
                [6.0, 7.24],
                [4.0, 4.26],
                [12.0, 10.84],
                [7.0, 4.82],
                [5.0, 5.68]
            ],
            type: 'scatter'
        }]
    });

}

function radar() {
    const radar = echarts.init(document.getElementById('radar'));

    radar.setOption({
        title: {
            text: '雷達圖示例'
        },
        radar: {
            indicator: [
                { name: '銷售', max: 100 },
                { name: '成本', max: 100 },
                { name: '利潤', max: 100 },
                { name: '市場', max: 100 },
                { name: '發展', max: 100 }
            ]
        },
        series: [
            {
                name: '指標',
                type: 'radar',
                data: [
                    {
                        value: [90, 80, 85, 70, 75],
                        name: '評分'
                    }
                ]
            }
        ]
    });

}