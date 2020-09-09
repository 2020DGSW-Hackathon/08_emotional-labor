import React, { Component } from 'react';

class Write extends Component {
    constructor(props) {
        super(props);
        this.state = {
            title : '',
            content: ''
        }
    
        this.titleChange = this.titleChange.bind(this);
        this.contentChange = this.contentChange.bind(this);
      }

      titleChange(event) {
          this.setState({title : event.target.content});
      }

      contentChange(event) {
          this.setState({content : event.target.content});
      }

    render() {
        return (
            <div className="Write-Container">
                <input type="text" value={this.state.title} onChange={this.titleChange}/>
                <textarea value={this.state.content} onChange={this.content}/>
            </div>
        );
    }
}

export default Write;