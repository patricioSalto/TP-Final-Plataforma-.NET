using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.Net.Http;

namespace DeskTopClientes
{
    public partial class FrmClientes : Form
    {
        string apiUrl = "http://localhost:49905/api/ApiClientes";
        int _Id = 0;
        int _idActualizarCliente = 0;
        public FrmClientes()
        {
            InitializeComponent();
            Refrescar_Grid();
        }

        private void Refrescar_Grid()
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl + "/GetAllClientes", "");

            dataGridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Entidades.ClienteModel>>(json);
            dataGridView1.ClearSelection();
        }

        private void Limpiar_Campos()
        {
            _Id = 0;
            txttipodocumento.Text = "";
            txtnrodocumento.Text = "";
            txtnombre.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            txtestado.Text = "";
        }

        private void btnMostarClientes_Click(object sender, EventArgs e)
        {
            Refrescar_Grid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txttipodocumento.Text.Length <= 10)
            {
                if(txtnrodocumento.Text.Length <= 20)
                {
                    if(txtnombre.Text.Length <= 255)
                    {
                        if(txtdireccion.Text.Length <= 255)
                        {
                            if(txttelefono.Text.Length <= 100)
                            {
                                if(txtcorreo.Text.Length <= 255)
                                {
                                    if(txtestado.Text.Length == 1)
                                    {
                                        Entidades.ClienteModel _datosCliente = new Entidades.ClienteModel()
                                        {
                                            Tipo_documento = txttipodocumento.Text,
                                            Nro_documento = txtnrodocumento.Text,
                                            Nombre = txtnombre.Text,
                                            Direccion = txtdireccion.Text,
                                            Telefono = txttelefono.Text,
                                            Correo = txtcorreo.Text,
                                            Estados = txtestado.Text
                                        };

                                        string inputJson = (new JavaScriptSerializer()).Serialize(_datosCliente);
                                        WebClient client = new WebClient();
                                        client.Headers["Content-type"] = "application/json";
                                        client.Encoding = Encoding.UTF8;
                                        string json = client.UploadString(apiUrl + "/InsertCliente", inputJson);
                                        Refrescar_Grid();
                                        Limpiar_Campos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El estado puede tener un maximo de 1 caracter");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El correo puede tener un maximo de 255 caracteres");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El telefono puede tener un maximo de 100 caracteres");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La direccion puede tener un maximo de 255 caracteres");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre puede tener un maximo de 255 caracteres");
                    }
                }
                else
                {
                    MessageBox.Show("El nro de documento puede tener un maximo de 20 caracteres");
                }
            }
            else
            {
                MessageBox.Show("El tipo de documento puede tener un maximo de 10 caracteres");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Entidades.ClienteModel _datosCliente = new Entidades.ClienteModel()
                    {
                        Id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString())
                    };
                    string inputJson = (new JavaScriptSerializer()).Serialize(_datosCliente);
                    WebClient client = new WebClient();
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string json = client.UploadString(apiUrl + "/GetClienteById", inputJson);

                    var outputDTO = (new JavaScriptSerializer()).Deserialize<Entidades.ClienteModel>(json);

                    txttipodocumento.Text = outputDTO.Tipo_documento;
                    txtnrodocumento.Text = outputDTO.Nro_documento;
                    txtnombre.Text = outputDTO.Nombre;
                    txtdireccion.Text = outputDTO.Direccion;
                    txttelefono.Text = outputDTO.Telefono;
                    txtcorreo.Text = outputDTO.Correo;
                    txtestado.Text = outputDTO.Estados;

                    _idActualizarCliente = outputDTO.Id;

                    btnGuardar.Visible = false;
                    btnEditar.Visible = false;
                    btnEditarCliente.Visible = true;

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elelemento");
                }
            }
            else
            {
                MessageBox.Show("No existen elementos en la grilla");
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text.Length <= 10)
            {
                if (txtnrodocumento.Text.Length <= 20)
                {
                    if (txtnombre.Text.Length <= 255)
                    {
                        if (txtdireccion.Text.Length <= 255)
                        {
                            if (txttelefono.Text.Length <= 100)
                            {
                                if (txtcorreo.Text.Length <= 255)
                                {
                                    if (txtestado.Text.Length == 1)
                                    {
                                        Entidades.ClienteModel _datosCliente = new Entidades.ClienteModel()
                                        {
                                            Id = _idActualizarCliente,
                                            Tipo_documento = txttipodocumento.Text,
                                            Nro_documento = txtnrodocumento.Text,
                                            Nombre = txtnombre.Text,
                                            Direccion = txtdireccion.Text,
                                            Telefono = txttelefono.Text,
                                            Correo = txtcorreo.Text,
                                            Estados = txtestado.Text
                                        };


                                        string inputJson = (new JavaScriptSerializer()).Serialize(_datosCliente);
                                        WebClient client = new WebClient();
                                        client.Headers["Content-type"] = "application/json";
                                        client.Encoding = Encoding.UTF8;
                                        string json = client.UploadString(apiUrl + "/ActualizarCliente", inputJson);

                                        btnGuardar.Visible = true;
                                        btnEditar.Visible = true;
                                        btnEditarCliente.Visible = false;

                                        Refrescar_Grid();
                                        Limpiar_Campos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El estado puede tener un maximo de 1 caracter");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El correo puede tener un maximo de 255 caracteres");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El telefono puede tener un maximo de 100 caracteres");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La direccion puede tener un maximo de 255 caracteres");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre puede tener un maximo de 255 caracteres");
                    }
                }
                else
                {
                    MessageBox.Show("El nro de documento puede tener un maximo de 20 caracteres");
                }
            }
            else
            {
                MessageBox.Show("El tipo de documento puede tener un maximo de 10 caracteres");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea eliminar al cliente?", "Eliminar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    Entidades.ClienteModel _datosCliente = new Entidades.ClienteModel()
                    {
                        Id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString())
                    };
                    string inputJson = (new JavaScriptSerializer()).Serialize(_datosCliente);
                    WebClient client = new WebClient();
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string json = client.UploadString(apiUrl + "/DeleteCliente", inputJson);

                    Refrescar_Grid();

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elelemento");
                }
            }
            else
            {
                MessageBox.Show("No existen elementos en la grilla");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtfiltro.Text == "")
            {

            }else
            {

            string inputJson = (new JavaScriptSerializer()).Serialize(txtfiltro.Text);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl + "/BuscarClientes", inputJson);

            btnMostrarClientes.Visible = true;

            dataGridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Entidades.ClienteModel>>(json);
            dataGridView1.ClearSelection();

            }
        }
    }
}
