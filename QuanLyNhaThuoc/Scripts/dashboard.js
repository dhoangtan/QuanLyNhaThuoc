/* globals Chart:false, feather:false */
const list = $('#mylist').data('list');
let currentDate = new Date();
let day = currentDate.getDate();
let month = currentDate.getMonth() + 1;
let year = currentDate.getFullYear();
let dateString = month + "-" + day + "-" + year;
console.log(dateString);

console.log(Date.now() - 7 * 24 * 60 * 60 * 1000);
console.log(list);
(function () {
  'use strict'

  feather.replace({ 'aria-hidden': 'true' })

  // Graphs
  var ctx = document.getElementById('myChart')
    const sevenDaysAgo = new Date(Date.now() - 6 * 24 * 60 * 60 * 1000);
    const listDate = [];
    for (let i = 0; i < 7; i++) {
        const date = new Date(sevenDaysAgo.getTime() + i * 24 * 60 * 60 * 1000);
        let day = date.getDate();
        let month = date.getMonth() + 1;
        let year = date.getFullYear();
        let formatDate = `${day}/${month}/${year}`;
        listDate.push(formatDate);
    }
    console.log(listDate);
  var myChart = new Chart(ctx, {
    type: 'line',
      data: {
          labels: listDate,
          datasets: [{
              data: list,
        lineTension: 0,
        backgroundColor: 'transparent',
        borderColor: '#007bff',
        borderWidth: 4,
        pointBackgroundColor: '#007bff'
      }]
    },
    options: {
      scales: {
        yAxes: [{
          ticks: {
            beginAtZero: false
          }
        }]
      },
      legend: {
        display: false
      }
    }
  })
})()
