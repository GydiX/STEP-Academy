using users_wf.DTOs;
using users_wf.Repositories;

namespace users_wf
{
    public partial class Register : Form
    {
        private readonly UserRepository _userRepository;
        private bool isRegister;

        public string? Email { get; private set; }

        public Register(UserRepository userRepository)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _userRepository = userRepository;
            isRegister = true;
            panelLogin.Visible = false;
            Email = null;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var userDto = new UserDTO
            {
                Age = (int)Math.Floor(numAge.Value),
                Email = tbEmail.Text,
                UserName = tbUsername.Text,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Role = "user"
            };

            var res = await _userRepository.AddUserAsync(userDto);

            if (res.Key)
            {
                Close();
            }
            else
            {
                MessageBox.Show(res.Value);
            }
        }

        private void FormChange_Click(object sender, EventArgs e)
        {
            if (isRegister)
            {
                panelRegister.Visible = false;
                panelLogin.Visible = true;
                Text = "Login";
                lblTitle.Text = "Login";
                isRegister = false;
            }
            else
            {
                panelRegister.Visible = true;
                panelLogin.Visible = false;
                Text = "Register";
                lblTitle.Text = "Register";
                isRegister = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmailLogin.Text;
            string username = tbUsernameLogin.Text;

            var res = await _userRepository.LoginAsync(email, username);

            if(res.Key)
            {
                Email = email;
                Close();
            }
            else
            {
                MessageBox.Show(res.Value);
            }
        }
    }
}
