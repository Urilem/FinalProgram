using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FinalProgram
{
    public partial class FrmVender : Form
    {
        private List<DetalleVenta> _detallesVenta = new List<DetalleVenta>();
        
        public FrmVender()
        {
            InitializeComponent();
            
            // Conectar eventos
            btnAgregar.Click += btnAgregar_Click;
            btnVender.Click += btnVender_Click;
            btnCancelar.Click += btnCancelar_Click;
            txtid.TextChanged += txtid_TextChanged;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            
            // Configurar DataGridView
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas
            tblProductos.AutoGenerateColumns = false;
            tblProductos.Columns.Clear();
            
            tblProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                Width = 150
            });
            
            tblProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80
            });
            
            tblProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitarioFormateado",
                Width = 100
            });
            
            tblProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "SubtotalFormateado",
                Width = 100
            });
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text, out int id) && id > 0)
            {
                var producto = Program.ProductoService.ObtenerPorId(id);
                if (producto != null)
                {
                    lblNombreProducto.Text = producto.Nombre;  // CORREGIDO
                    lblPrecio.Text = producto.Precio.ToString("C2");
                    CalcularPrecioFinal();
                }
                else
                {
                    lblNombreProducto.Text = "Producto no encontrado";  // CORREGIDO
                    lblPrecio.Text = "$0.00";
                    label1.Text = "$0.00";
                }
            }
            else
            {
                lblNombreProducto.Text = "Ingrese ID para buscar producto";  // CORREGIDO
                lblPrecio.Text = "$0.00";
                label1.Text = "$0.00";
            }
        }

        private void CalcularPrecioFinal()
        {
            if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
            {
                if (decimal.TryParse(lblPrecio.Text.Replace("$", "").Replace(",", ""), out decimal precioUnitario))
                {
                    decimal precioFinal = precioUnitario * cantidad;
                    label1.Text = precioFinal.ToString("C2");
                }
            }
            else
            {
                label1.Text = "$0.00";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int productoId) || productoId <= 0)
                {
                    MessageBox.Show("ID de producto inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var producto = Program.ProductoService.ObtenerPorId(productoId);
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (producto.Stock < cantidad)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {producto.Stock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var detalle = new DetalleVenta
                {
                    Producto = producto,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                };

                var detalleExistente = _detallesVenta.FirstOrDefault(d => d.Producto.Id == productoId);
                if (detalleExistente != null)
                {
                    detalleExistente.Cantidad += cantidad;
                }
                else
                {
                    _detallesVenta.Add(detalle);
                }

                ActualizarTablaVenta();
                CalcularTotalGeneral();
                
                txtid.Clear();
                lblNombreProducto.Text = "Ingrese ID para buscar producto";  // CORREGIDO
                txtCantidad.Clear();
                lblPrecio.Text = "$0.00";
                label1.Text = "$0.00";
                
                txtid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTablaVenta()
        {
            var bindingList = new BindingList<DetalleVenta>(_detallesVenta);
            var source = new BindingSource(bindingList, null);
            tblProductos.DataSource = source;
        }

        private void CalcularTotalGeneral()
        {
            decimal total = _detallesVenta.Sum(d => d.Subtotal);
            lblPrecioF.Text = $"Total: {total:C2}";
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_detallesVenta.Any())
                {
                    MessageBox.Show("Agregue productos a la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal totalVenta = _detallesVenta.Sum(d => d.Subtotal);
                
                var resultado = MessageBox.Show(
                    $"¿Confirmar venta por un total de {totalVenta:C2}?",
                    "Confirmar Venta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    foreach (var detalle in _detallesVenta)
                    {
                        Program.ProductoService.VenderProducto(detalle.Producto.Id, detalle.Cantidad);
                    }

                    // Mostrar ticket
                    using (var frmTicket = new FrmTicket(_detallesVenta, totalVenta))
                    {
                        frmTicket.ShowDialog();
                    }

                    MessageBox.Show("¡Venta realizada exitosamente!", "Éxito", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _detallesVenta.Clear();
                    ActualizarTablaVenta();
                    CalcularTotalGeneral();
                    
                    txtid.Clear();
                    lblNombreProducto.Text = "Ingrese ID para buscar producto";  // CORREGIDO
                    txtCantidad.Clear();
                    lblPrecio.Text = "$0.00";
                    label1.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta: {ex.Message}", "Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de cancelar la venta? Se perderán todos los productos agregados.",
                "Cancelar Venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioFinal();
        }

        private void label1_Click(object sender, EventArgs e) { }

        // CORREGIDO: Cambiar el nombre del método para que coincida con el diseñador
        private void tblProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
