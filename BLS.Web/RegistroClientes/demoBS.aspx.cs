using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace BLS.Web.RegistroClientes
{
    public partial class demoBS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {


            lblErrorTerminos.Visible = false;

            // Validar Términos y Política
            if (!frmAltaCliente_E3.Checked || !frmAltaCliente_E4.Checked)
            {
                lblErrorTerminos.Text = "Debes aceptar los Términos y Condiciones y la Política de Privacidad.";
                lblErrorTerminos.Visible = true;
                return;
            }

            string password = txtPassword.Text;
            string confirmPassword = txtConfirPassword.Text;

            // 2️ Coincidencia
            if (password != confirmPassword)
            {
                lblErrorTerminos.Text = "Las contraseñas no coinciden.";
                lblErrorTerminos.Visible = true;
                return;
            }

            // 3️ Longitud mínima
            if (password.Length < 8)
            {
                lblErrorTerminos.Text = "La contraseña debe tener al menos 8 caracteres.";
                lblErrorTerminos.Visible = true;
                return;
            }

            // 4️ Reglas de seguridad
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                lblErrorTerminos.Text = "La contraseña debe contener al menos una letra mayúscula.";
                lblErrorTerminos.Visible = true;
                return;
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                lblErrorTerminos.Text = "La contraseña debe contener al menos una letra minúscula.";
                lblErrorTerminos.Visible = true;
                return;
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                lblErrorTerminos.Text = "La contraseña debe contener al menos un número.";
                lblErrorTerminos.Visible = true;
                return;
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                lblErrorTerminos.Text = "La contraseña debe contener al menos un símbolo.";
                lblErrorTerminos.Visible = true;
                return;
            }

            pnlResgistro.Visible = false;

            pnlPaquetes.Visible = true;
        }

        protected void btnGratis_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("4 Pruebas Gratis", 0);
        }

        protected void btn20_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("20 Créditos", 100);
        }

        protected void btn50_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("50 Créditos", 200);
        }

        protected void btn100_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("100 Créditos", 400);
        }

        private void SeleccionarPaquete(string nombre, int precio)
        {
            // Guardar temporalmente
            Session["PaqueteNombre"] = nombre;
            Session["PaquetePrecio"] = precio;

            // Mostrar resumen
            lblPlan.Text = nombre;
            lblPrecio.Text = precio.ToString();

            pnlPaquetes.Visible = false;
            pnlResumen.Visible = true;
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            pnlResumen.Visible = false;
            pnlPaquetes.Visible = true;

        }
    }
}