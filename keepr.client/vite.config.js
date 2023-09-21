import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    outDir: 'docs',
    sourcemap: false
  },
  server: {
    host: true,
    port: 8081,
    strictPort: true,
    hmr: {
      host: 'jaredcarlson.dev',
      port: 8082,
      protocol: 'wss'
    }
  },
  base: '/keepr/'
})
