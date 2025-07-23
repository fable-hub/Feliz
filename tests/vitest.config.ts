import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react';

console.log('loading vitest config');

export default defineConfig(({ mode }) => ({
  plugins: [react()],
  test: {
    globals: true, // enables afterEach `cleanup` from RTL. Without this all components will stay mounted after each test
    include: ['**/*.{test,spec}.?(c|m|fs.)[jt]s?(x)'],
    environment: 'jsdom',
    setupFiles: ['./vitest-setup.ts'],
  },
}));
