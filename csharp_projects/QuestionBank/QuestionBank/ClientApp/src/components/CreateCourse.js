import React from 'react'

const CreateCourse = () => {
    return (
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Course Code</label>
                        <input class="form-control" />
                    </div>
                    <div class="form-group">
                        <label class="control-label">Course Title</label>
                        <input class="form-control" />
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    )
}

export default CreateCourse
