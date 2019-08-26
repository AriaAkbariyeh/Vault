using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vault.Core
{
    public class Password
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Passphrase { get; set; }
    }
}
