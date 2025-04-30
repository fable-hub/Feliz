import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react';

console.log('loading vitest config');

export default defineConfig(({ mode }) => ({
  plugins: [react()],
  test: {
    environment: 'jsdom',
    setupFiles: ['./vitest-setup.ts'],
  },
}));
