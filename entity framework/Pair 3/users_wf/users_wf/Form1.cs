using AutoMapper;
using users_wf.MapperProfiles;
using users_wf.Models;
using users_wf.Repositories;

namespace users_wf
{
    public partial class Form1 : Form
    {
        private User? user;

        private readonly AppDbContext _context;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly Mapper _mapper;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            user = null;

            _context = new AppDbContext();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMapperProfile>();
            });

            _mapper = new Mapper(mapperConfig);
            _roleRepository = new RoleRepository(_context);
            _userRepository = new UserRepository(_context, _roleRepository, _mapper);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Register registerForm = new Register(_userRepository);
            registerForm.ShowDialog();
            string? userEmail = registerForm.Email;

            if (userEmail != null)
            {
                user = await _userRepository.FindByEmailAsync(userEmail, true);

                if(user != null)
                {
                    label1.Text = label1.Text.Replace("userEmail", user.Email);
                    label1.Visible = true;
                }
            }
        }
    }
}
