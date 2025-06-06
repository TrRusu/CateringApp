export default defineNuxtConfig({
  ssr: false,

  app: {
    head: {
      charset: 'utf-16',
      title: 'Diversity App',
      meta: [
        {
          name: 'description',
          content: 'An app that will improve the most process in a business',
        },
      ],
      link: [
        {
          rel: 'stylesheet',
          href: 'https://fonts.googleapis.com/css2?family=Manrope:wght@400;600;700&display=swap',
        },
      ],
    },

    pageTransition: { name: 'page', mode: 'out-in' },
  },

  modules: [
    [
      '@pinia/nuxt',
      {
        autoImports: ['defineStore'],
      },
    ],
  ],

  css: ['@/assets/scss/reset.scss'],

  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: '@import "@/assets/scss/_colors.scss";',
        },
      },
    },
  },

  runtimeConfig: {
    public: {
      apiBaseUrl: 'https://localhost:7101/api',
      apiKey: 'goedeapikey'
    }
  }
})
