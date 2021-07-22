'use strict';

const secretNumber = Math.trunc(Math.random() * 20) + 1;
let score = 20;
let highScore = 0;

const displayMessage = function (message) {
    document.querySelector('.message').textContent = message;
};

// Again Event Listener
document.querySelector('.again').addEventListener('click', async function () {
    score = 20;

    document.querySelector('.score').textContent = score;
    document.querySelector('.message').textContent = `Start guessing..`;
    document.querySelector('.number').textContent = '?';
    document.querySelector('.guess').value = null;

    document.querySelector('.number').style.width = '15rem';
    document.querySelector('body').style.backgroundColor = '#222';

    await fetch('http://localhost:2020/data', {
        method: 'DELETE'
    })

});

// Check Event Listener
document.querySelector('.check').addEventListener('click', async function () {
    const guess = Number(document.querySelector('.guess').value);

    if (!guess) {
        displayMessage(`🤦‍♂ No Number !`);

        //When player wins
    } else if (guess === secretNumber) {
        displayMessage(`🎉 Correct Answer`);

        document.querySelector('body').style.backgroundColor = '#60b347';
        document.querySelector('.number').style.width = '30rem';
        document.querySelector('.number').textContent = secretNumber;

        //HighScore
        if (score > highScore) {
            highScore = score;
            document.querySelector('.highscore').textContent = highScore;
        }

        // guess is not equal to secretNumber (Refracting the code)
    } else if (guess !== secretNumber) {
        if (score > 1) {
            document.querySelector('.message').textContent =
                guess > secretNumber
                    ? `☝ Guess is too high`
                    : (document.querySelector(
                        '.message'
                    ).textContent = `👇 Guess is too low`);
            score--;
            document.querySelector('.score').textContent = score;
        } else {
            document.querySelector('.message').textContent = `🐱‍👤Game Over`;
            document.querySelector('.score').textContent = 0;
        }
    }
    console.log(score)
    await fetch('http://localhost:2020/data', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ score }),
    });

    const res = await fetch('http://localhost:2020/data');
    const data = await res.json();
    console.log(data.highScore);
});
function submit() {
    var model = new Object();
    model.UserId = '@us.UserId';
    model.Score = score;
    jQuery.ajax({
        method: "POST",
        url: '@Url.Action("Update")',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({ std: model }),
        success: function (data) {
            alert('saved', 500);
},
failure: function () {
    alert('error');
}
    })
}