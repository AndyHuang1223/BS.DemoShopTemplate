;(function IIFE() {
	const api = {
	}

	const apiCaller = {
	}

	Vue.component('v-chart', VueECharts)

	const homeIndexVue = new Vue({
		el: '#home-index',
		data: {
			cards: {
				monthlyEarnings: 40000,
				annualEarnings: 80000,
				memberSums: 120,
				goodsSums: 40
			},
      // 營收折線圖
      earningsLinesChartOption: {
        xAxis: {
          type: 'category',
          data: ['週一', '週二', '週三', '週四', '週五', '週六', '週日']
        },
        yAxis: {
          type: 'value'
        },
        series: [
          {
            data: [820, 932, 901, 934, 1290, 1330, 1320],
            type: 'line',
            smooth: true
          }
        ]
      },
      // 商品庫存直條圖
      goodsBarsChartOption: {
        yAxis: {
          type: 'category',
          data: ['商品A','商品B','商品C','商品D',]
        },
        xAxis: {
          type: 'value'
        },
        series: [
          {
            data: [120, 200, 150, 80],
            type: 'bar',
            showBackground: true,
            backgroundStyle: {
              color: 'rgba(180, 180, 180, 0.2)'
            }
          }
        ]
      },
      // 會員成長折線圖
      memberGrowLinesChartOption: {
        xAxis: {
          type: 'category',
          boundaryGap: false,
          data: ['5月', '6月', '7月', '8月', '9月', '10月']
        },
        yAxis: {
          type: 'value'
        },
        series: [
          {
            data: [],
            type: 'line',
            smooth: true,
            areaStyle: {}
          }
        ]
      },
      // 分類圓餅圖
      categoryPiesChartOption: {
        tooltip: {
          trigger: 'item'
        },
        legend: {
          orient: 'vertical',
          left: 'left'
        },
        series: [
          {
            name: '分類',
            type: 'pie',
            radius: '50%',
            data: [
              { value: 48, name: '禮盒' },
              { value: 75, name: '餅乾' },
              { value: 50, name: '蛋糕' },
              { value: 44, name: '優惠券' },
              { value: 30, name: '公益' }
            ],
            emphasis: {
              itemStyle: {
                shadowBlur: 10,
                shadowOffsetX: 0,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
              }
            }
          }
        ]
      }
		},
    mounted() {
      setTimeout(() => {
        this.memberGrowLinesChartOption.series[0].data = [82, 93, 100, 110, 129, 133, 144]
      }, 1000);
    },
		methods: {}
	})
})()
