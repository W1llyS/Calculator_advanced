        // Keyboard support
    document.addEventListener('keydown', function (event) {
            const key = event.key;
    const display = document.getElementById('TextBoxVysledek');

    // Prevent default for calculator keys
    if ('0123456789+-*/.='.includes(key) || key === 'Enter' || key === 'Escape') {
        event.preventDefault();
            }

    // Number keys
    if ('0123456789'.includes(key)) {
                const btn = document.querySelector(`input[value="${key}"]`);
    if (btn) btn.click();
            }

    // Operator keys
    switch (key) {
                case '+':
    document.getElementById('<%= ButtonPlus.ClientID %>').click();
    break;
    case '-':
    document.getElementById('<%= ButtonMinus.ClientID %>').click();
    break;
    case '*':
    document.getElementById('<%= ButtonMultiplication.ClientID %>').click();
    break;
    case '/':
    document.getElementById('<%= ButtonDivision.ClientID %>').click();
    break;
    case '.':
    document.getElementById('<%= ButtonDot.ClientID %>').click();
    break;
    case 'Enter':
    case '=':
    document.getElementById('<%= ButtonSpocitat.ClientID %>').click();
    break;
    case 'Escape':
    case 'c':
    case 'C':
    document.getElementById('<%= ButtonC.ClientID %>').click();
    break;
            }
        });

        // Add visual feedback for button presses
        document.querySelectorAll('.calculator button').forEach(button => {
        button.addEventListener('click', function () {
            this.style.transform = 'scale(0.96)';
            setTimeout(() => {
                this.style.transform = '';
            }, 150);
        });
        });

    // Auto-focus display on page load
    window.addEventListener('load', function () {
        document.getElementById('TextBoxVysledek').focus();
        });

        // Add smooth hover effects
        document.querySelectorAll('.calculator button').forEach(button => {
        button.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-2px)';
        });

    button.addEventListener('mouseleave', function () {
        this.style.transform = '';
            });
        });
