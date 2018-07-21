import React from "react";
import { todoRecord_create } from "./server";
import {
  RadioGroup,
  RadioButton,
  ReversedRadioButton
} from "react-radio-buttons";

class Todo extends React.Component {
  state = {
    title: "",
    priority: "",
    status: "",
    dueDate: ""
  };

  postTodo = () => {
    const data = {
      title: this.state.title,
      priority: this.state.priority,
      status: "In Progress",
      dueDate: this.state.dueDate
    };
    debugger;
    todoRecord_create(data)
      .then(resp => {
        debugger;
        this.setState({
          title: "",
          priority: "",
          status: "",
          dueDate: ""
        });
      })
      .catch(err => {
        alert(err);
      });
  };

  handleOptionChange = e => {
    this.setState({
      priority: e.target.value
    });
  };

  render() {
    return (
      <div>
        <h2 className="animated rubberBand" id="title">
          Todo List
        </h2>
        <div className="container row">
          <div className="col-md-3" id="form">
            <form>
              <h5>Title</h5>
              <input
                type="text"
                placeholder="Assignment Title..."
                className="form-control"
                value={this.state.title}
                onChange={e => {
                  this.setState({ title: e.target.value });
                }}
              />
              <h5>Priority</h5>
              <fieldset
                id="priority"
                data-role="controlgroup"
                data-type="horizontal"
              >
                <input
                  type="radio"
                  value="high"
                  checked={this.state.priority === "high"}
                  onChange={this.handleOptionChange}
                />
                <label for="high">High</label>
                <input
                  type="radio"
                  value="medium"
                  checked={this.state.priority === "medium"}
                  onChange={this.handleOptionChange}
                />
                <label for="medium">Medium</label>
                <input
                  type="radio"
                  value="low"
                  checked={this.state.priority === "low"}
                  onChange={this.handleOptionChange}
                />
                <label for="low">Low</label>
              </fieldset>
              <h5>Due Date</h5>
              <input
                type="text"
                placeholder="Due Date..."
                className="form-control"
                value={this.state.dueDate}
                onChange={e => {
                  this.setState({ dueDate: e.target.value });
                }}
              />
              <button
                type="button"
                className="btn btn-md btn-block btn-success"
                onClick={this.postTodo}
              >
                Submit
              </button>
            </form>
          </div>
        </div>
      </div>
    );
  }
}

export default Todo;
