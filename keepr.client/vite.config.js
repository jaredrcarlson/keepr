import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'
import { servePath, servePort } from './src/env.js'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    sourcemap: false
  },
  server: {
    host: true,
    port: servePort,
    strictPort: true,
    hmr: false
  },
  base: servePath
})
