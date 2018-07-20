import React from "react";
import { todoRecord_create } from "./server";

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
      status: this.state.status,
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

  onStatusChanged = (e) => {
    this.setState({
        status: e.target.value
    });
  }

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
                  name="priority"
                  id="high"
                  value={this.state.priority}
                  onChange={e => {
                    this.setState({ priority: e.target.value });
                  }}
                />
                <label for="high">High</label>
                <input
                  type="radio"
                  name="priority"
                  id="medium"
                  value={this.state.priority}
                  onChange={e => {
                    this.setState({ priority: e.target.value });
                  }}
                />
                <label for="medium">Medium</label>
                <input
                  type="radio"
                  name="priority"
                  id="low"
                  value={this.state.priority}
                  onChange={e => {
                    this.setState({ priority: e.target.value });
                  }}
                />
                <label for="low">Low</label>
              </fieldset>
              <h5>Status</h5>
              <fieldset
                id="status"
                data-role="controlgroup"
                data-type="horizontal"
              >
                <input
                  type="radio"
                  name="status"
                  id="inProgress"
                  value={this.state.status}
                  onClick={this.onStatusChanged}
                />
                <label for="inProgress">In Progress</label>
                <input
                  type="radio"
                  name="status"
                  id="complete"
                  value={this.state.status}
                  onClick={this.onStatusChanged}
                />
                <label for="complete">Complete</label>
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
