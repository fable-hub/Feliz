import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react';
import { time } from 'console';

console.log('loading vitest config');

export default defineConfig(({ mode }) => ({
  plugins: [react()],
  test: {
    globals: true, // enables afterEach `cleanup` from RTL. Without this all components will stay mounted after each test
    include: ['**/*.{test,spec}.?(c|m|fs.)[jt]s?(x)'],
    environment: 'jsdom',
    setupFiles: ['./vitest-setup.ts'],
    tags: [
      {
        name: 'async',
        description: 'Async tests requiring long timeouts.',
        timeout: 20_000,
      },
      {
        name: 'activeDev',
        description: 'Tests currently under active development. Meant to be used to run as filtered tests during development. Do not push these tags to version control. Remove this tag once the test is stable and can be run in CI.',
      }
    ]
  },
}));
