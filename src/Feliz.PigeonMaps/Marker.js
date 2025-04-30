import { Component, createElement } from 'react'

class Marker extends Component {

    constructor(props) {
        super(props)

        this.state = {
            hover: false
        }
    }

    // what do you expect to get back with the event
    eventParameters(event) {
        return {
            anchor: this.props.anchor
        }
    }

    // controls
    isRetina() {
        return typeof window !== 'undefined' && window.devicePixelRatio >= 2
    }

    // modifiers
    isHover() {
        return typeof this.props.hover === 'boolean' ? this.props.hover : this.state.hover
    }

    // delegators

    handleClick(event) {
        this.props.onClick && this.props.onClick(this.eventParameters(event))
    }

    handleContextMenu(event) {
        this.props.onContextMenu && this.props.onContextMenu(this.eventParameters(event))
    }

    handleMouseOver(event) {
        this.props.onMouseOver && this.props.onMouseOver(this.eventParameters(event))
        this.setState({ hover: true })
    }

    handleMouseOut(event) {
        this.props.onMouseOut && this.props.onMouseOut(this.eventParameters(event))
        this.setState({ hover: false })
    }

    // render

    render() {
        const { left, top } = this.props

        const style = {
            position: 'absolute',
            transform: `translate(${left - (this.props.offsetLeft || 0)}px, ${top - (this.props.offsetTop || 0)}px)`
        }

        return (
            createElement('div', {
                style: style,
                onClick: this.handleClick.bind(this),
                onContextMenu: this.handleContextMenu.bind(this),
                onMouseOver: this.handleMouseOver.bind(this),
                onMouseOut: this.handleMouseOut.bind(this),
                children: this.props.render && this.props.render({ hovered: this.state.hover, anchor: this.props.anchor })
            })
        )
    }
}


export const createMarker = function (extraProps) {
    return createElement(Marker, { ...extraProps })
}