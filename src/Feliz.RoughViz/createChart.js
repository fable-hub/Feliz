import * as RoughViz from '@inocan/rough-viz'

export const createBarChart = (config) => new RoughViz.Bar(config)

export const createHorizontalBarChart = (config) => new RoughViz.BarH(config)

export const createPieChart = (config) => new RoughViz.Pie(config)