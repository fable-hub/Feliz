import '@testing-library/jest-dom/vitest';
import {cleanup} from '@testing-library/react'
import {afterEach} from 'vitest'

console.log("vitest-setup.ts loaded")

afterEach(cleanup)
