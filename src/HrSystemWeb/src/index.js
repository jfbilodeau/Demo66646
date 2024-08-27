(() => {
    const hr = window.hr || {}

    window.hr = hr

    hr.init = async () => {
        console.log('HrSystemWeb initialized')

        const response = await fetch('https://hremployeeservice.azurewebsites.net/api/employee/', {
            method: 'GET',
            mode: 'cors',
        })

        console.log(response)

        if (response.ok) {
            const employees = await response.json()

            const employeeList = document.getElementById('employeesTableBody')

            employees.forEach(employee => {
                const employeeTr = document.createElement('tr')
                const employeeIdTd = document.createElement('td')
                const employeeNameTd = document.createElement('td')
                const employeeSalaryTd = document.createElement('td')
                const employeeDeptTd = document.createElement('td')

                employeeIdTd.textContent = employee.id
                employeeNameTd.textContent = `${employee.firstName} ${employee.lastName}`
                employeeSalaryTd.textContent = employee.salary
                employeeDeptTd.textContent = employee.dept

                employeeTr.appendChild(employeeIdTd)
                employeeTr.appendChild(employeeNameTd)
                employeeTr.appendChild(employeeSalaryTd)
                employeeTr.appendChild(employeeDeptTd)

                employeeList.appendChild(employeeTr)
            })

            const employeeMessage = document.getElementById('employeesMessage')
            employeeMessage.textContent = 'Employees fetched successfully'

            const employeesTable = document.getElementById('employeesTable')
            employeesTable.hidden = false
        } else {
            console.error('Failed to fetch employees')

            const employeeMessage = document.getElementById('employeesMessage')
            employeeMessage.textContent = 'Failed to fetch employees'
        }
    }

    window.addEventListener('load', hr.init)
})()