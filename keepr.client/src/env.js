export const dev = typeof window !== "undefined" ? window.location.origin.includes('localhost') : true
export const baseURL = dev ? 'https://localhost:7045' : ''
export const servePath = dev ? '' : '/keepr/'
export const servePort = 8081
export const useSockets = false
export const domain = 'dev-eux5v4apdr8nm4hz.us.auth0.com'
export const audience = 'classroom2'
export const clientId = 'Rur2HYRUEOc9CFa5kFMGh67L2LmsuzQH'