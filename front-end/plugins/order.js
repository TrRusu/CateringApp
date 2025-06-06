export default defineNuxtPlugin(() => {
  return {
    provide: {
      convert: (price) => {
        const parsedPrice = parseFloat(price)

        return new Intl.NumberFormat('nl-NL', {
          style: 'currency',
          currency: 'EUR',
        }).format(parsedPrice / 100)
      },
      date: (moment) => {
        const month = moment.toLocaleString("en-us", { month: "short"})
        const day = moment.getDay()
        const time = `${moment.getUTCHours()}:${moment.getMinutes()}`

        return `${month} ${day} at ${time}`
      }
    },
  }
})
