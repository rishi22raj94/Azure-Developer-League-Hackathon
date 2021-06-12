var personName;
var personAge;
var personPlace;
personName = "Rishi";
personAge = 28;
personPlace = "Hyderabad";
function GetPersonInfo() {
    return `${personName} is ${personAge} years old and he is registering as a student and currently residing in ${personPlace}`;
}
class HttpFetchService {
    Post(url, payload, name2, age, email) {
        const promise = new Promise((resolve, reject) => {
            let formData = new FormData();
            formData.append('Name', name2);
            formData.append('Age', age.toString());
            formData.append('Email', email);
            fetch(url, {
                method: 'POST',
                body: formData
            }).then((response) => {
                //if (!response.ok) {
                //    alert(response.statusText)
                //}
                
                return response.json();
            })
                .then(function (result) {
                
                resolve(result);
            }).catch((error) => {
                console.error('Error:', error);
            });
        });
        return promise;
    }
}
class SampleRequest {
}
//Controller  Json return values should be same as this class
class SampleResponse {
}
class SampleService extends HttpFetchService {
}
//autobind decorator
function autobind(target, methodName, descriptor) {
    const originalMethod = descriptor.value;
    const adjDescriptor = {
        configurable: true,
        get() {
            const boundFn = originalMethod.bind(this);
            return boundFn;
        }
    };
    return adjDescriptor;
}
function validate(validatableInput) {
    let isValid = true;
    if (validatableInput.required) {
        isValid = isValid && validatableInput.value.toString().trim().length !== 0;
    }
    if (validatableInput.minLength != null &&
        typeof validatableInput.value === 'string') {
        isValid =
            isValid && validatableInput.value.length >= validatableInput.minLength;
    }
    if (validatableInput.maxLength != null &&
        typeof validatableInput.value === 'string') {
        isValid =
            isValid && validatableInput.value.length <= validatableInput.maxLength;
    }
    if (validatableInput.min != null &&
        typeof validatableInput.value === 'number') {
        isValid = isValid && validatableInput.value >= validatableInput.min;
    }
    if (validatableInput.max != null &&
        typeof validatableInput.value === 'number') {
        isValid = isValid && validatableInput.value <= validatableInput.max;
    }
    return isValid;
}
class PopupSave {
    constructor() {
        this.editstdform = document.getElementById("project");
        this.btn = document.getElementById("Student");
        this.label = document.getElementById('#text');
        let id = this.btn.dataset.modelvalue;
        this.NameInputElement = this.editstdform.querySelector("#name");
        this.AgeInputElement = this.editstdform.querySelector("#age");
        this.EmailInputElement = this.editstdform.querySelector("#email");
        //if (this.StudentID.value != null)
        //    alert("Student_" + this.StudentID.value)
        //let id2 = this.dynamicsave_element(this.btn.id);
        //this.btn.addEventListener("click", this.submitHandler.bind(this))
        this.configure(id);
    }
    setValue(node) {
        var txtBoxValue = document.getElementById(node.value);
        alert(txtBoxValue);
    }
    dynamicsave_element(id) {
        alert(id);
    }
    configure(id) {
        //this.btn.addEventListener("click", this.submitHandler.bind(this,id))
        this.editstdform.addEventListener("submit", this.submitHandler.bind(this, id));
    }
    gatherUserInput() {
        const enteredName = this.NameInputElement.value;
        const enteredAge = this.AgeInputElement.value;
        const enteredEmail = this.EmailInputElement.value;
        const nameValidatable = {
            value: enteredName,
            required: true,
            minLength: 3
        };
        const ageValidatable = {
            value: +enteredAge,
            required: true,
            min: 18,
            max: 99
        };
        const emailValidatable = {
            value: enteredEmail,
            required: true,
            minLength: 5
        };
        if (!validate(nameValidatable) ||
            !validate(ageValidatable) ||
            !validate(emailValidatable)) {
            alert("Invalid input,please try again!");
            return;
        }
        else {
            return [enteredName, +enteredAge, enteredEmail];
        }
    }
    clearInputs() {
        this.NameInputElement.value = "";
        this.AgeInputElement.value = "";
        this.EmailInputElement.value = "";
    }
    //@autobind
    submitHandler(event, id) {
        
        alert(id);
        event.preventDefault();
        const userInput = this.gatherUserInput();
        if (Array.isArray(userInput)) {
            const [name, age, email] = userInput;
            const httpService = new SampleService();
            
            httpService.Post('/Home/EditPartial', {}, userInput[0], userInput[1], userInput[2])
                .then((model) => {
                alert(model.title);
                alert(model.email1234);
            });
            //this.clearInputs();
        }
    }
}
var PopupSaveModule;
(function (PopupSaveModule) {
    PopupSaveModule.test = new PopupSave();
})(PopupSaveModule || (PopupSaveModule = {}));
